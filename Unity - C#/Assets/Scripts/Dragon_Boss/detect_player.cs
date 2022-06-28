using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect_player : MonoBehaviour
{
    public GameObject target;
    bool is_on=false;
    // Start is called before the first frame update
    void Awake()
    {
        target = GameManager.Player;
    }

    private void Update()
    {
        if (target == null)
            target = GameManager.Player;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Damge ennemy shoot
            is_on=true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Damge ennemy shoot
            is_on=false;
        }
    }

    public bool detect_joueur()
    {
        return is_on;
    }
}
