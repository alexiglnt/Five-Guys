using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gestion_vie_dead_dragon : MonoBehaviour
{
    [SerializeField] GameObject tp;
    public float health;
    float maxHealth;
    public Image vie_jauge;
    Animator Player_anim;
    bool oui = false;
    // Start is called before the first frame update
    void Start()
    {
        Player_anim=GetComponent<Animator>();
        maxHealth=health;
    }

    public void TakeDamage(int damage)
    {
        if(transform.Find("pylones_gestion").GetComponent<pylones_gestion>().sans_defense()==true)
        {
            health -= damage;
            if(health<=0 && !oui)
            {
                oui = true;
                Player_anim.SetBool("dead",true);
                Instantiate(tp, this.gameObject.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            vie_jauge.fillAmount = health * (1/maxHealth);
        }
    }

    public float get_health()
    {
        return health;
    }

    public float get_max_health()
    {
        return maxHealth;
    }
}
