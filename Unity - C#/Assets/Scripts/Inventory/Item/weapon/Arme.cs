using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Arme", menuName = "Inventory/Item/Arme")]
public class Arme : Item
{


    public int damage;
    public int magazine_size;
    public float reload_time;
    public int Max_mun;
    public int bullet_speed;
    public float bullet_life_time;
    public float fire_rate;
}
