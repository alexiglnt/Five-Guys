using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_follow : MonoBehaviour
{
    public Transform target;
    bool oui = false;
    

    void Update()
    {
        if (target == null)
        {
            if (oui == false)
            {
                target = GameObject.Find("BOSS").transform;
                oui = true;
            }
            else
                Destroy(gameObject);
        }
        else
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
