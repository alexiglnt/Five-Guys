using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemi_dep : MonoBehaviour
{
    float maxSpeed=300;
    Rigidbody2D playerRB;
    public GameObject target;
    Animator playerAnim;
    bool view_once=false;
    // Start is called before the first frame update
    void Awake()
    {
        target = GameManager.Player;
        playerRB =GetComponent<Rigidbody2D>();
        playerAnim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target == null)
            target = GameManager.Player;

        if (view_once==true)
        {
            start_dep();
        }
        if(transform.Find("detect_area").GetComponent<detect_player>().detect_joueur()==true)
        {
            view_once=true;
        Vector3 target_pos=target.transform.position;
        Vector3 perso=transform.position;
        float distance=Vector3.Distance(target_pos,perso);
        Vector2 diff=new Vector2(target_pos.x-perso.x,target_pos.y-perso.y);
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

    void start_dep()
    {
        Vector3 target_pos=target.transform.position;
        Vector3 perso=transform.position;
        Vector2 diff=new Vector2(target_pos.x-perso.x,target_pos.y-perso.y);
        float distance=Vector3.Distance(target_pos,perso);
        playerRB.AddForce(new Vector3(diff.normalized.x*10,diff.normalized.y*10), ForceMode2D.Force);
    }

}
