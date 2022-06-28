using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attaq : MonoBehaviour
{
    Animator playerAnim;
    bool shot;
    public GameObject balle;
    public GameObject target;
    public Transform Depart_balle;
    bool first_view=false;
    public GameObject infos;
    // Start is called before the first frame update
    void Awake()
    {
        playerAnim=GetComponent<Animator>();
        target = GameManager.Player;
    }

    // Update is called once per frame

    void Update()
    {
        if (target == null)
            target = GameManager.Player;

        if (transform.Find("detect_area").GetComponent<detect_player>().detect_joueur()==true && first_view==false)
        {
            GameManager.IsInCinematic = true;
            first_view=true;
            Instantiate(infos,transform.position, Quaternion.identity);
            playerAnim.SetBool("awake",true);
            Camera.main.GetComponent<CameraFollow>().SetTarget(this.gameObject.transform);
        }
    }

    public void in_att()
    {
        if(first_view==true)
        {
            shot=true;
            StartCoroutine(comp1());
        }   
    }

    public void off_att()
    {
        shot=false;
    }

    IEnumerator comp1()
    {
        while(shot==true)
        {
            yield return new WaitForSeconds(0.3f);
            GameObject new_b=Instantiate(balle,Depart_balle.position, Quaternion.identity);
            new_b.GetComponent<flamme>().shot(target);
        }
    }

    public void stop_cinematic()
    {
        GameManager.IsInCinematic = false;
        Camera.main.GetComponent<CameraFollow>().SetTarget(target.transform);
    }

    public void stop_awake()
    {
        playerAnim.SetBool("awake",false);
        stop_cinematic();
    }
}
