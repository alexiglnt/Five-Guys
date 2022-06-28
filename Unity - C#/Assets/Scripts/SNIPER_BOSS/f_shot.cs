using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class f_shot : MonoBehaviour
{
    public GameObject balle;
    public Transform Depart_balle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(balle,Depart_balle.position, Quaternion.identity);
        }
    }
}
