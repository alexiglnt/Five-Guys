using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pylone_activation : MonoBehaviour
{
    public Sprite actif;
    public Sprite desactif;
    SpriteRenderer sr;
    bool is_actif=false;
    public float duree;
    float last_activation;
    int index_pyl;
    // Start is called before the first frame update
    void Start()
    {
        sr=GetComponent<SpriteRenderer>();
        sr.sprite=desactif;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(is_actif)
        {
            if(last_activation>0)
            {
                last_activation-=Time.deltaTime;
            }
            else
            {
                is_actif=false;
                sr.sprite=desactif;
            }
        }
    }

    public void activate(int index)
    {
        index_pyl=index;
        sr.sprite=actif;
        is_actif=true;
        last_activation=duree;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(is_actif==true)
        {
            if(col.gameObject.tag=="ammo")
            {
                transform.parent.GetComponent<pylones_gestion>().remove(index_pyl);
                Destroy(this.gameObject);
            }
        }
    }
}
