using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gestion_vie_dead_ennemi : MonoBehaviour
{
    [SerializeField] GameObject tp;
    public float health;
    float maxHealth;
    public Image vie_jauge;
    Animator Player_anim;
    public bool im_a_boss;
    bool oui;
    // Start is called before the first frame update
    void Start()
    {
        Player_anim=GetComponent<Animator>();
        maxHealth=health;
        oui = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health<=0)
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (0,0);
            Player_anim.SetBool("dead",true);
            if(im_a_boss==true && !oui)
            {
                oui = true;
                Instantiate(tp, this.gameObject.transform.position, Quaternion.identity);
            }
        }
        vie_jauge.fillAmount = health * (1/maxHealth);
    }

    public float get_health()
    {
        return health;
    }

    public float get_max_health()
    {
        return maxHealth;
    }

    public void detruire()
    {
        Destroy(this.gameObject);
    }
}
