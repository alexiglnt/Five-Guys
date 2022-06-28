using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dep_loup : MonoBehaviour
{
    float maxSpeed=300;
    Rigidbody2D playerRB;
    public GameObject target;
    Animator playerAnim;
    bool already_shot=false;
    bool view_first=false;
    public GameObject infos;

    // Start is called before the first frame update
    void Start()
    {
        target = GameManager.Player;
        playerRB=GetComponent<Rigidbody2D>();
        playerAnim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            target = GameManager.Player;

        if(view_first==false)
        {
            if(transform.Find("detect_area").GetComponent<detect_player>().detect_joueur()==true)
            {
                GameManager.IsInCinematic = true;
                Instantiate(infos,transform.position, Quaternion.identity);
                playerAnim.SetBool("awake",true);
                view_first=true;
                Camera.main.GetComponent<CameraFollow>().SetTarget(this.gameObject.transform);
            }
        }
        else if(GameManager.IsInCinematic == false)
        {
            if(transform.Find("detect_area").GetComponent<detect_player>().detect_joueur()==true)
        {
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
        if(distance<5)
        {
            playerAnim.SetBool("is_rolling", false);
            already_shot=false;
            int x_d=Random.Range(-1,2);
            int y_d=Random.Range(-1,2);
            playerRB.AddForce(new Vector3(x_d*diff.normalized.x*5,y_d*diff.normalized.y*5), ForceMode2D.Impulse);
        }
        else{
            playerAnim.SetBool("is_rolling", true);
            if(already_shot==false)
            {
                StartCoroutine(GetComponent<shot_loup>().comp1());
                already_shot=true;
            }
            playerRB.AddForce(new Vector3(diff.normalized.x*0.4f,diff.normalized.y*0.4f), ForceMode2D.Impulse);
        }
        }
        }
    }

    public void stop_cinematic()
    {
        Camera.main.GetComponent<CameraFollow>().SetTarget(target.transform);
        GameManager.IsInCinematic = false;
    }

    public void stop_awake()
    {
        playerAnim.SetBool("awake",false);
        stop_cinematic();
    }
}
