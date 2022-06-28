using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aim_joueur : MonoBehaviour
{
    SpriteRenderer sp;
    public Transform g;
    public Transform d;
    // Start is called before the first frame update
    void Start()
    {
        sp=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mp=Input.mousePosition;
        Vector3 perso=Camera.main.WorldToScreenPoint(transform.position);
        Vector2 diff=new Vector2(mp.x-perso.x,mp.y-perso.y);
        float angle=Mathf.Atan2(diff.y,diff.x)*Mathf.Rad2Deg;
        if(angle<90 && angle>-90)
        {
            sp.flipY=false;
        }
        else
        {
            sp.flipY=true;
        }
        transform.rotation=Quaternion.Euler(0f,0f,angle);
    }
}
