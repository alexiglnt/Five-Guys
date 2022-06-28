using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDungeonGeneratorEditor : MonoBehaviour
{
    [SerializeField]
    private AbstractDungeonGenerator generator;

    private void Start()
    {
        generator.GenerateDungeon();
    }

}
