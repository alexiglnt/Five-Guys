using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dep_sniper : MonoBehaviour
{
    float maxSpeed=1;
    Rigidbody2D playerRB;
    private GameObject target;
    Animator playerAnim;
    bool view_first=false;
    public GameObject infos;
    // Start is called before the first frame update
    void Awake()
    {
        target = GameManager.Player;
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
            start_dep();
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
        playerRB.AddForce(new Vector3(diff.normalized.x,diff.normalized.y), ForceMode2D.Force);
    }

    public void stop_cinematic()
    {
        GameManager.IsInCinematic = false;
        Camera.main.GetComponent<CameraFollow>().SetTarget(GameManager.Player.transform);
    }

    public void stop_awake()
    {
        Debug.Log("sniper");
        playerAnim.SetBool("awake",false);
        stop_cinematic();
    }
}