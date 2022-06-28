using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aim_target : MonoBehaviour
{
    SpriteRenderer sp;
    public Transform laser;
    public Transform g;
    public Transform d;
    public GameObject target;
    // Start is called before the first frame update
    void Awake()
    {
        target = GameManager.Player;
        sp =GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            target = GameManager.Player;
        Vector3 target_pos=target.transform.position;
        Vector3 perso=transform.position;
        Vector2 diff=new Vector2(target_pos.x-perso.x,target_pos.y-perso.y);
        float angle=Mathf.Atan2(diff.y,diff.x)*Mathf.Rad2Deg;
        if(angle<90 && angle>-90)
        {
            sp.flipY=false;
            laser.position=d.position;
        }
        else
        {
            sp.flipY=true;
            laser.position=g.position;
        }
        transform.rotation=Quaternion.Euler(0f,0f,angle);
    }
}
