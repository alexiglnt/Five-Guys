using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aim_laser : MonoBehaviour
{
    bool facingRight = true;
    public Transform g;
    public Transform d; 

    public void Flip()
    {
        if(facingRight==true)
        {
            transform.position=d.position;
        }
        else{
            transform.position=g.position;
        }
        facingRight=!facingRight;
    }
}
