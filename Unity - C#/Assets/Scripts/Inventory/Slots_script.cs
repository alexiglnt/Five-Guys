using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots_script : MonoBehaviour
{
    public GameObject Slot;
    public Item inventoryItem;
    public Transform target;
    public GameObject inventory;
    public GameObject displayPassif;


    public GameObject inventory_weapon;
    public GameObject inventory_weapon_display;

    private int numberOfColumn = 19;
    private int PosX;
    private int PosY;
    private bool isSelect = false;

    public Text attack;
    public Text defense;
    public Text speed;
    public Text health;
    public Text luck;

    public Image artwork;

    private bool next;

    public int mun;
    public int mag;


    void Awake()
    {
        inventory = GameObject.Find("Inventory_display");
        displayPassif = GameObject.Find("Passif_display");

        inventory_weapon = GameObject.Find("Inventory_weapon");
        inventory_weapon_display = GameObject.Find("Inventory_weapon_display");


        attack = displayPassif.transform.Find("attack").GetComponent<Text>();
        defense = displayPassif.transform.Find("defense").GetComponent<Text>();
        speed = displayPassif.transform.Find("speed").GetComponent<Text>();
        health = displayPassif.transform.Find("health").GetComponent<Text>();
        luck = displayPassif.transform.Find("luck").GetComponent<Text>();

        artwork = displayPassif.transform.Find("artwork").GetComponent<Image>();

        
        attack.text = "Attack : ";
        defense.text = "Defense : ";
        speed.text = "Speed : ";
        health.text = "Health : ";
        luck.text = "Luck : ";



    }


    public void select()
    {


        foreach (Transform child in inventory.transform)
        {

            if (child.gameObject.GetComponent<Slots_script>().isSelect == true)
            {
                child.gameObject.GetComponent<Slots_script>().isSelect = false;
            }
        }
        Passif P = (Passif)inventoryItem;

        attack.text = "Attack : " + P.attack;
        defense.text = "Defense : " + P.defense;
        speed.text = "Speed : " + P.speed;
        health.text = "Health : " + P.health;
        luck.text = "Luck : " + P.luck;
        
        artwork.sprite = P.artwork;

        isSelect = true;
        Debug.Log("selectionn�");
        Debug.Log(isSelect);
    }   
    
    
    
    public void selectWeaponNext()
    {
        target = GameObject.Find("HAND").transform;
        inventory_weapon = GameObject.Find("Inventory_weapon");
        inventory_weapon_display = GameObject.Find("inventory_weapon_display");
        
        next = false;

        

        

        foreach (Transform child in inventory_weapon_display.transform)
        {

            if (next)
            {
                child.gameObject.GetComponent<Slots_script>().isSelect = true;
                GameObject weapon = child.gameObject.GetComponent<Slots_script>().inventoryItem.InsantiateItem(target.transform);
                weapon.transform.parent = target.transform;
                weapon.gameObject.GetComponent<weapon_script>().magazine = child.gameObject.GetComponent<Slots_script>().mag;
                weapon.gameObject.GetComponent<weapon_script>().mun = child.gameObject.GetComponent<Slots_script>().mun;
                weapon.gameObject.GetComponent<weapon_script>().enabled = true;
                break;

            }
            else if (child.gameObject.GetComponent<Slots_script>().isSelect == true)
            {
                child.gameObject.GetComponent<Slots_script>().isSelect = false;
                child.gameObject.GetComponent<Slots_script>().mag = target.GetChild(0).gameObject.GetComponent<weapon_script>().magazine;
                child.gameObject.GetComponent<Slots_script>().mun = target.GetChild(0).gameObject.GetComponent<weapon_script>().mun;
                foreach (Transform HAND_child in target)
                {
                    GameObject.Destroy(HAND_child.gameObject);
                }
                next = true;
            }
        }

        if (next == false)
        {
            Transform child = inventory_weapon_display.transform.GetChild(0);
            child.gameObject.GetComponent<Slots_script>().isSelect = true;
            GameObject weapon = child.gameObject.GetComponent<Slots_script>().inventoryItem.InsantiateItem(target.transform);
            weapon.transform.parent = target.transform;
            weapon.gameObject.GetComponent<weapon_script>().magazine = child.gameObject.GetComponent<Slots_script>().mag;
            weapon.gameObject.GetComponent<weapon_script>().mun = child.gameObject.GetComponent<Slots_script>().mun;
            weapon.gameObject.GetComponent<weapon_script>().enabled = true;
        }
    }


    public void removeFromInventory()
    {
        inventory = GameObject.Find("Inventory_display");
        foreach (Transform child in inventory.transform)
        {
            if (child.gameObject.GetComponent<Slots_script>().isSelect == true)
            {
                try
                {
                    Passif P = (Passif)child.gameObject.GetComponent<Slots_script>().inventoryItem;
                    PlayerStats.instance.maxHealth -= P.health;
                    PlayerStats.instance.health -= P.health;
                    PlayerStats.instance.attack -= P.attack;
                    PlayerStats.instance.defense -= P.defense;
                    PlayerStats.instance.speed -= P.speed;
                    PlayerStats.instance.luck -= P.luck;


                }
                catch
                {
                    Debug.Log("Not a passif");
                }
                    displayPassif = GameObject.Find("Passif_display");
        
                
        
                    attack = displayPassif.transform.Find("attack").GetComponent<Text>();
                    defense = displayPassif.transform.Find("defense").GetComponent<Text>();
                    speed = displayPassif.transform.Find("speed").GetComponent<Text>();
                    health = displayPassif.transform.Find("health").GetComponent<Text>();
                    luck = displayPassif.transform.Find("luck").GetComponent<Text>();

                    artwork = displayPassif.transform.Find("artwork").GetComponent<Image>();


                    attack.text = "Attack : ";
                    defense.text = "Defense : ";
                    speed.text = "Speed : ";
                    health.text = "Health : ";
                    luck.text = "Luck : ";

                    artwork.sprite = null;


                target = GameManager.Player.transform;
                child.gameObject.GetComponent<Slots_script>().inventoryItem.InsantiateItem(target.transform);
                Inventory.instance.RemoveItem(child.gameObject.GetComponent<Slots_script>().inventoryItem);

                child.gameObject.GetComponent<Slots_script>().gameObject.transform.SetParent(target.transform, false);


                Destroy(child.gameObject.GetComponent<Slots_script>().gameObject);
            }
        }
       

      
    }
    
}
