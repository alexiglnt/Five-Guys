using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakable_object : MonoBehaviour
{
    Animator Player_anim;
    // Start is called before the first frame update
    void Start()
    {
        Player_anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="ammo")
        {
            Player_anim.SetBool("break",true);
        }
    }

    public void detruire()
    {
        Destroy(this.gameObject);
    }
}
