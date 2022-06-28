using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destauto : MonoBehaviour
{
    public float aliveTime;
    void Start()
    {
        Destroy(gameObject, aliveTime);
    }

}
