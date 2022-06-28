using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomFirstDungeonGenerator : SimpleRandomWalkDungeonGenerator
{
    [SerializeField]
    private GameObject start_weapon;
    [SerializeField]
    private int minRoomWidth = 4, minRoomHeight = 4;
    [SerializeField]
    private int dungeonWidth = 20, dungeonHeight = 20;
    [SerializeField]
    [Range(0,10)]
    private int offset = 1;
    [SerializeField]
    private bool randomWalkRooms = false;
    [SerializeField]
    private GameObject Chests;
    [SerializeField]
    private GameObject[] BOSS;
    [SerializeField]
    private GameObject[] Ennemies;
    [SerializeField]
    private GameObject[] Breakables;


    protected override void RunProceduralGeneration()
    {
        CreateRooms();
    }

    private void CreateRooms()
    {
        var roomsList = ProceduralGenerationAlgorithms.BinarySpacePartitioning(new BoundsInt((Vector3Int)startPosition, new Vector3Int(dungeonWidth, dungeonHeight, 0)), minRoomWidth, minRoomHeight);

        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();

        if (randomWalkRooms)
        {
            floor = CreateRoomsRandomly(roomsList);
        }
        else
        {
            floor = CreateSimpleRooms(roomsList);
        }
        

        List<Vector2Int> roomCenters = new List<Vector2Int>();
        foreach (var room in roomsList)
        {
            roomCenters.Add((Vector2Int)Vector3Int.RoundToInt(room.center));
        }
        
        int index_start_room=Random.Range(1, roomCenters.Count);
        Vector2Int start = roomCenters[index_start_room];
        int index_boss=Random.Range(0,BOSS.Length);
        GameObject player=GameManager.Player;

        if (GameManager._currentLevelName != "Lvl2")
        {
            Destroy(GameObject.Find("player"));
            GameManager.Player = Instantiate(player, new Vector3(start.x, start.y, 0), Quaternion.identity);
            GameManager.Player.name = "player";
        }       
        else
            GameManager.Player.transform.position = new Vector3(start.x, start.y, 0);

        GameObject new_boss=Instantiate(BOSS[index_boss], new Vector3(roomCenters[0].x, roomCenters[0].y, 0), Quaternion.identity);
        new_boss.transform.Find("detect_area").GetComponent<BoxCollider2D>().size =  new Vector2(roomsList[0].size.x/10,roomsList[0].size.y/10);
        new_boss.transform.Find("detect_area").transform.position =new Vector3(roomCenters[0].x,roomCenters[0].y, 0);
        new_boss.name="BOSS";
        
        for (int i = 1; i < roomsList.Count; i++)
        {
            if(index_start_room!=i)
            {
                Instantiate(Chests, (Vector3)(roomsList[i].center), Quaternion.identity);
                int nbr_ennemis=Random.Range(3,7);
                for(int j=0;j<nbr_ennemis;j++)
                {
                    int index_ennemi=Random.Range(0,Ennemies.Length);
                    int x_pos;
                    int y_pos;
                    x_pos=Random.Range(-(roomsList[i].size.x/3),roomsList[i].size.x/3);
                    y_pos=Random.Range(-(roomsList[i].size.y/3),roomsList[i].size.y/3);
                    GameObject new_ennemy=Instantiate(Ennemies[index_ennemi], new Vector3(roomCenters[i].x+x_pos,roomCenters[i].y+y_pos, 0), Quaternion.identity);
                    new_ennemy.transform.Find("detect_area").GetComponent<BoxCollider2D>().size =  new Vector2(roomsList[i].size.x/10,roomsList[i].size.y/10);
                    new_ennemy.transform.Find("detect_area").transform.position =new Vector3(roomCenters[i].x,roomCenters[i].y, 0);
                }
                int nbr_break=Random.Range(4,7);
                for(int k=0;k<nbr_break;k++)
                {
                    int index_break=Random.Range(0,Breakables.Length);
                    int x_pos;
                    int y_pos;
                    x_pos=Random.Range(-(roomsList[i].size.x/3),roomsList[i].size.x/3);
                    y_pos=Random.Range(-(roomsList[i].size.y/3),roomsList[i].size.y/3);
                    Instantiate(Breakables[index_break], new Vector3(roomCenters[i].x+x_pos,roomCenters[i].y+y_pos, 0), Quaternion.identity);
                }
            }
            else if (GameManager._currentLevelName != "Lvl2")
                Instantiate(start_weapon, (Vector3)(roomsList[index_start_room].center), Quaternion.identity);
            
        }
        HashSet<Vector2Int> corridors = ConnectRooms(roomCenters);
        floor.UnionWith(corridors);

        tilemapVisualizer.PaintFloorTiles(floor);
        WallGenerator.CreateWalls(floor, tilemapVisualizer);
    }

    private HashSet<Vector2Int> CreateRoomsRandomly(List<BoundsInt> roomsList)
    {
        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
        for (int i = 0; i < roomsList.Count; i++)
        {
            var roomBounds = roomsList[i];
            var roomCenter = new Vector2Int(Mathf.RoundToInt(roomBounds.center.x), Mathf.RoundToInt(roomBounds.center.y));
            var roomFloor = RunRandomWalk(randomWalkParameters, roomCenter);
            foreach (var position in roomFloor)
            {
                if(position.x >= (roomBounds.xMin + offset) && position.x <= (roomBounds.xMax - offset) && position.y >= (roomBounds.yMin - offset) && position.y <= (roomBounds.yMax - offset))
                {
                    floor.Add(position);
                }
            }
        }
        return floor;
    }

    private HashSet<Vector2Int> ConnectRooms(List<Vector2Int> roomCenters)
    {
        HashSet<Vector2Int> corridors = new HashSet<Vector2Int>();
        var currentRoomCenter = roomCenters[Random.Range(0, roomCenters.Count)];
        roomCenters.Remove(currentRoomCenter);

        while (roomCenters.Count > 0)
        {
            Vector2Int closest = FindClosestPointTo(currentRoomCenter, roomCenters);
            roomCenters.Remove(closest);
            HashSet<Vector2Int> newCorridor = CreateCorridor(currentRoomCenter, closest);
            currentRoomCenter = closest;
            corridors.UnionWith(newCorridor);
        }
        return corridors;
    }

    private HashSet<Vector2Int> CreateCorridor(Vector2Int currentRoomCenter, Vector2Int destination)
    {
        HashSet<Vector2Int> corridor = new HashSet<Vector2Int>();
        var position = currentRoomCenter;
        corridor.Add(position);
        while (position.y != destination.y)
        {
            if(destination.y > position.y)
            {
                position += Vector2Int.up;
            }
            else if(destination.y < position.y)
            {
                position += Vector2Int.down;
            }
            corridor.Add(position);
        }
        while (position.x != destination.x)
        {
            if (destination.x > position.x)
            {
                position += Vector2Int.right;
            }else if(destination.x < position.x)
            {
                position += Vector2Int.left;
            }
            corridor.Add(position);
        }
        return corridor;
    }

    private Vector2Int FindClosestPointTo(Vector2Int currentRoomCenter, List<Vector2Int> roomCenters)
    {
        Vector2Int closest = Vector2Int.zero;
        float distance = float.MaxValue;
        foreach (var position in roomCenters)
        {
            float currentDistance = Vector2.Distance(position, currentRoomCenter);
            if(currentDistance < distance)
            {
                distance = currentDistance;
                closest = position;
            }
        }
        return closest;
    }
    

    private HashSet<Vector2Int> CreateSimpleRooms(List<BoundsInt> roomsList)
    {
        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
        foreach (var room in roomsList)
        {
            for (int col = offset; col < room.size.x - offset; col++)
            {
                for (int row = offset; row < room.size.y - offset; row++)
                {
                    Vector2Int position = (Vector2Int)room.min + new Vector2Int(col, row);
                    floor.Add(position);
                }
            }
        }
        return floor;
    }
}

