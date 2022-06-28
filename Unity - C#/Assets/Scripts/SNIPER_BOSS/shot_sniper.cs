using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot_sniper : MonoBehaviour
{
    public GameObject balle;
    public GameObject pierce_balle;
    public GameObject pierce_loading;
    public GameObject grenade;
    public GameObject mine;
    public GameObject target;
    GameObject current_mine;
    public GameObject big_mine;
    
    public float time_beetween_mine;
    public float time_beetween_gre;
    public int nbrshot_beetween_big_shot;
    int nbr_shots;
    float last_mine;
    float last_gre;
    public Transform Depart_balle;
    Animator playeranim;
    bool view_first=false;
    int phase=1;

    // Start is called before the first frame update
    void Awake()
    {
        target = GameManager.Player;        
        last_mine =time_beetween_mine;
        last_gre=time_beetween_gre;
        nbr_shots=0;
        current_mine=mine;
        playeranim=GetComponent<Animator>();
    }

    void reveil()
    {
        playeranim.SetBool("awake",true);
        StartCoroutine(comp1());
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
            target = GameManager.Player;
        if (transform.Find("detect_area").GetComponent<detect_player>().detect_joueur()==true && view_first==false && GameManager.IsInCinematic == false)
        {
            reveil();
            view_first=true;
        }

    }

    void FixedUpdate()
    {
        if(transform.Find("detect_area").GetComponent<detect_player>().detect_joueur()==true)
        {
        if(last_mine>0)
        {
            last_mine-=Time.deltaTime;
        }
        else{
            comp3();
            last_mine=time_beetween_mine;
        }
        if(last_gre>0)
        {
            last_gre-=Time.deltaTime;
        }
        else{
            StartCoroutine(comp2());
            last_gre=time_beetween_gre;
        }
        }
    }

    IEnumerator comp1()
    {
        nbr_shots+=1;
        for(int i=0;i<4;i++)
        {
            yield return new WaitForSeconds(0.2f);
            GameObject new_b=Instantiate(balle,Depart_balle.position, Quaternion.identity);
            new_b.GetComponent<balle>().shot(target);
        }
        if(nbr_shots>=nbrshot_beetween_big_shot)
        {
            nbr_shots=0;
            StartCoroutine(comp4());
        }
        else{
            StartCoroutine(comp1());
        }
    }

       public IEnumerator comp2()
    {
        for(int i=-3;i<3;i++)
        {
            yield return new WaitForSeconds(0.1f);
            GameObject new_g=Instantiate(grenade,new Vector2(Depart_balle.position.x,Depart_balle.position.y+(Mathf.Abs(i)*1)), Quaternion.identity);
            new_g.GetComponent<grenadine>().shot(target);
        }
    }

    void comp3()
    {
        Instantiate(current_mine,transform.position, Quaternion.identity);
    }

    public IEnumerator comp4()
    {
        GameObject load=Instantiate(pierce_loading,Depart_balle.position, Quaternion.identity);
        load.transform.SetParent(Depart_balle,true);
        yield return new WaitForSeconds(3f);
        Destroy(load);
        GameObject new_pb=Instantiate(pierce_balle,Depart_balle.position, Quaternion.identity);
        new_pb.GetComponent<balle>().shot(target);
        StartCoroutine(comp1());
    }

    IEnumerator comp5()
    {
        for(int i=0;i<4;i++)
        {
            yield return new WaitForSeconds(0.1f);
            GameObject new_b=Instantiate(balle,Depart_balle.position, Quaternion.identity);
            new_b.GetComponent<balle>().shot(target);
        }
        StartCoroutine(comp5());
    }

    IEnumerator comp6()
    {
        GameObject load=Instantiate(pierce_loading,Depart_balle.position, Quaternion.identity);
        load.transform.SetParent(Depart_balle,true);
        yield return new WaitForSeconds(3f);
        Destroy(load);
        GameObject new_pb=Instantiate(pierce_balle,Depart_balle.position, Quaternion.identity);
        new_pb.GetComponent<balle>().shot(target);
        StartCoroutine(comp6());
    }



}
