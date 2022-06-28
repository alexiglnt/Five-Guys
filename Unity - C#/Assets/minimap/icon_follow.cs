using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icon_follow : MonoBehaviour
{

    public Transform target;
    

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            target = GameManager.Player.transform;
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
