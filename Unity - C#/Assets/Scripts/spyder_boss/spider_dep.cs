using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider_dep : MonoBehaviour
{
    Vector2 target;
    Rigidbody2D playerRB;
    Animator playerAnim;
    bool on_base;
    float speed=13f;
    bool shot=false;
    bool view_first=false;
    public GameObject infos;

    // Start is called before the first frame update
    void Start()
    {
        target=transform.position;
        playerRB=GetComponent<Rigidbody2D>();
        playerAnim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<gestion_vie_dead_spyder>().get_health()/GetComponent<gestion_vie_dead_spyder>().get_max_health()<=0.5)
        {
            speed=17;
            GetComponent<spider_shot>().set_nbr_balles(3);
        }
        if(view_first==false)
        {
            if(transform.parent.Find("detect_area").GetComponent<detect_player>().detect_joueur()==true)
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
        Vector2 perso=transform.position;
        Vector2 diff=new Vector2(target.x-perso.x,target.y-perso.y);
        float distance=Vector2.Distance(target,perso);
        Debug.Log(distance);
        float angle=Mathf.Atan2(diff.y,diff.x)*Mathf.Rad2Deg;
        if(distance<0.6)
        {
            on_base=true;
            playerAnim.SetBool("is_moving", false);
            playerRB.velocity =new Vector2(0,0);
            if(shot==false)
            {
                StartCoroutine(GetComponent<spider_shot>().shot());
                shot=true;
            }
        }
        else{
            playerAnim.SetBool("is_moving", true);
            playerRB.velocity = diff.normalized * speed;
            shot=false;
            on_base=false;
        }
        }
    }

    public void deplace(Vector2 position_cible)
    {
        target=position_cible;
    }

    public bool is_on_base()
    {
        return on_base;
    }

    public void stop_cinematic()
    {
        GameManager.IsInCinematic = false;
        Camera.main.GetComponent<CameraFollow>().SetTarget(GameManager.Player.transform);
    }

    public void stop_awake()
    {
        playerAnim.SetBool("awake",false);
        stop_cinematic();
    }
}
