using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class f_dep : MonoBehaviour
{
    float maxSpeed=7;
    Rigidbody2D playerRB;
    Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerRB=GetComponent<Rigidbody2D>();
        playerAnim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveh = Input.GetAxis("Horizontal");
        float movev = Input.GetAxis("Vertical");
        playerRB.velocity = new Vector2(moveh * maxSpeed, movev*maxSpeed);
        Vector3 mp=Input.mousePosition;
        Vector3 perso=Camera.main.WorldToScreenPoint(transform.localPosition);
        Vector2 diff=new Vector2(mp.x-perso.x,mp.y-perso.y);
        float angle=Mathf.Atan2(diff.y,diff.x)*Mathf.Rad2Deg;
        if(angle<90 && angle>-90)
        {
            transform.eulerAngles=new Vector3(0,0,0);
        }
        else
        {
            transform.eulerAngles=new Vector3(0,180,0);
        }
    }
}
