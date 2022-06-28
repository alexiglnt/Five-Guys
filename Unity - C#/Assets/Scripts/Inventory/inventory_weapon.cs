using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory_weapon : MonoBehaviour
{
    #region Singleton
    public static inventory_weapon instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }
    #endregion

    public GameObject Slot;

    public List<Item> items = new List<Item>();

    public Transform target;

    public void AddItem(Item item)
    {
        if (!item.isDefaultItem)
        {
            items.Add(item);
        }
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

}