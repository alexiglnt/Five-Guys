using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider_base : MonoBehaviour
{
    public Transform[] bases;
    float intervalle=3;
    float chrono;
    // Start is called before the first frame update
    void Start()
    {
        chrono=0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        chrono-=Time.deltaTime;
        if(chrono<0)
        {
          int lequel=Random.Range(0,bases.Length);
          GetComponent<spider_dep>().deplace(bases[lequel].position);
          chrono=intervalle;
        }
    }
}
