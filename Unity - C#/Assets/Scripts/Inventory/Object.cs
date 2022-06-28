using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object : Interactable
{
    public GameObject Slot;
    public GameObject inventory;
    public GameObject Inventory_weapon;
    

    public bool isPick;
    public Animator animator;
    public Item item;

    private int PosX;
    private int PosY;

    private int numberOfColumn = 19;

    public void Start()
    {
        inventory = GameObject.Find("Inventory_display");
        Inventory_weapon = GameObject.Find("inventory_weapon_display");
    }

    public void TakePassif()
    {
        if (!isPick)
        {
            Passif P = (Passif)item;
            
            isPick = true;
            Debug.Log("You taked the object");

            //creer le slot dans l'inventaire               
            Slot.GetComponent<Image>().sprite = P.artwork;

            PosX = ((30 * (Inventory.instance.items.Count)+1)+ 10);

            PosY = Screen.height-5;

            var myNewSlot = Instantiate(Slot, new Vector2(PosX, PosY), Quaternion.identity);
            myNewSlot.transform.SetParent(inventory.transform, false);

            //rajoute dans l'inventaire
            Inventory.instance.AddItem(P);

            PlayerStats.instance.maxHealth += P.health;
            PlayerStats.instance.health += P.health;
            PlayerStats.instance.attack += P.attack;
            PlayerStats.instance.defense += P.defense;
            PlayerStats.instance.speed += P.speed;
            PlayerStats.instance.luck += P.luck;

            myNewSlot.GetComponent<Slots_script>().inventoryItem = Inventory.instance.items[Inventory.instance.items.Count-1];
            animator.SetBool("isPick", isPick);

            SortInventory();
        }
    }

    public void TakeWeapon()
    {
        Inventory_weapon = GameObject.Find("inventory_weapon_display");
        if (!isPick)
        {
            Arme W = (Arme)item;

            isPick = true;
            Debug.Log("You taked the object");

            //creer le slot dans l'inventaire               
            Slot.GetComponent<Image>().sprite = W.artwork;

            PosX = ((30 * (inventory_weapon.instance.items.Count) + 1) + 10);

            PosY = -Screen.height+30 ;

            var myNewSlot = Instantiate(Slot, new Vector2(PosX, PosY), Quaternion.identity);
            myNewSlot.transform.SetParent(Inventory_weapon.transform, false);

            //rajoute dans l'inventaire
            inventory_weapon.instance.AddItem(W);

            myNewSlot.GetComponent<Slots_script>().inventoryItem = inventory_weapon.instance.items[inventory_weapon.instance.items.Count - 1];
            myNewSlot.GetComponent<Slots_script>().mun = W.Max_mun;
            myNewSlot.GetComponent<Slots_script>().mag = W.magazine_size;


            animator.SetBool("isPick", isPick);

            SortInventory();
        }
    }

    public void TakeActif()
    {
        if (!isPick)
        {
            Actif A = (Actif)item;

            isPick = true;
            Debug.Log("You taked the object");

            //creer le slot dans l'inventaire               
            Slot.GetComponent<Image>().sprite = A.artwork;

            PosX = (30 * ((Inventory.instance.items.Count)+1) + 10);

            PosY = Screen.height-5;


            var myNewSlot = Instantiate(Slot, new Vector2(PosX, PosY), Quaternion.identity);
            myNewSlot.transform.SetParent(inventory.transform, false);
            //rajoute dans l'inventaire
            Inventory.instance.AddItem(A);

            myNewSlot.GetComponent<Slots_script>().inventoryItem = Inventory.instance.items[Inventory.instance.items.Count-1];
            animator.SetBool("isPick", isPick);
 
        }
    }

    public void SortInventory()
    {
        inventory = GameObject.Find("Inventory_display");
        int i = 0;

        foreach (Transform child in inventory.transform)
        {

            PosX = 10 + 30 * (i+1);


            PosY = Screen.height-5;


            child.transform.position = new Vector2(PosX, PosY);
            i++;
        }
    }

    public void droite()
    {
        inventory = GameObject.Find("Inventory_display");

        foreach (Transform child in inventory.transform)
        { 
            child.transform.position = new Vector2(child.transform.position.x-30, child.transform.position.y);
        }

    }

    public void gauche()
    {
        inventory = GameObject.Find("Inventory_display");

        foreach (Transform child in inventory.transform)
        {

            child.transform.position = new Vector2(child.transform.position.x+30, child.transform.position.y);
        }

    }


    public virtual void destroy()
    {
        Destroy(gameObject);
    }



}
