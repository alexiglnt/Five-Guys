using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_script_ennemi : MonoBehaviour
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
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(arme.damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "breakable")
        {
            Destroy(gameObject);
        }
    }
}
