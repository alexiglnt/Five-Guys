using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public bool isDefaultItem = false;

    public new string name;
    public string description;

    public Sprite artwork;

    public int rank;

    public GameObject prefab;

    public void Print()
    {
        Debug.Log(name + ": " + description);
    }

    public  GameObject InsantiateItem(Transform target)
    {
        return Instantiate(prefab, target.position, Quaternion.identity);
    }

}
