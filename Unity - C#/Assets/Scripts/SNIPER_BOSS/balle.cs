using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balle : MonoBehaviour
{
    public int degats;
    public Camera cam;
    public GameObject explose;
    public float speed;
    Rigidbody2D playerRB; 


    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("touch�");
        if (collision.gameObject.tag == "Player")
        {
            //Damge ennemy shoot
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(degats);
            Destroy(gameObject);
        }
    }

    public void shot(GameObject target)
    {
        playerRB = GetComponent<Rigidbody2D>();
        Vector3 target_pos=target.transform.position;
        Vector3 perso=transform.position;
        Vector2 diff=new Vector2(target_pos.x-perso.x,target_pos.y-perso.y);
        float angle=Mathf.Atan2(diff.y,diff.x)*Mathf.Rad2Deg;
        transform.rotation=Quaternion.Euler(0f,0f,angle);
        playerRB.velocity = diff.normalized * speed;
    }
}
