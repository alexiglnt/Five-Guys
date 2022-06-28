using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadine : MonoBehaviour
{
    public Camera cam;
    public GameObject explose;
    Rigidbody2D playerRB; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void shot(GameObject target)
    {
        playerRB = GetComponent<Rigidbody2D>();
        Vector3 target_pos=target.transform.position;
        Vector3 perso=transform.position;
        Vector2 diff=new Vector2(target_pos.x-perso.x,target_pos.y-perso.y);
        float angle=Mathf.Atan2(diff.y,diff.x)*Mathf.Rad2Deg;
        transform.rotation=Quaternion.Euler(0f,0f,angle);
        playerRB.velocity = diff.normalized * 10;
    }
}
