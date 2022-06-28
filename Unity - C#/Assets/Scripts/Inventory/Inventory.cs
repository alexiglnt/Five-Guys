using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton
    public static Inventory instance;

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

    public CanvasGroup canvasGroup;

    public GameObject Slot;

    public bool canShoot;


    public KeyCode interactKeyOpen;

    
    public List<Item> items = new List<Item>();

    public Transform target;

    void Start()
    { 
        canShoot= true;
    }

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

    void Update()
    {

        if (Input.GetKeyDown(interactKeyOpen))
        {
            Debug.Log("Vous avez appuyer sur I ");
            if (canvasGroup.alpha==0)
            {
                canvasGroup.alpha = 1;
                canShoot = false;
                
            }
            else
            {
                canvasGroup.alpha = 0;
                canShoot = true;  
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("Select_weapon");
            Slot.GetComponent<Slots_script>().selectWeaponNext();
        }

    }
    
}
