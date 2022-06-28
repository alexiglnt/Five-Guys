using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_script : MonoBehaviour
{
    public Rigidbody2D rb;
    public Arme arme;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * arme.bullet_speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ennemies")
        {
            //Damge ennemy shoot
            collision.gameObject.GetComponent<gestion_vie_dead_ennemi>().TakeDamage(arme.damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "dragon_boss")
        {
            //Damge ennemy shoot
            collision.gameObject.GetComponent<gestion_vie_dead_dragon>().TakeDamage(arme.damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "spider_boss")
        {
            //Damge ennemy shoot
            collision.gameObject.GetComponent<gestion_vie_dead_spyder>().TakeDamage(arme.damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "breakable")
        {
            Destroy(gameObject);
        }
    }
}
