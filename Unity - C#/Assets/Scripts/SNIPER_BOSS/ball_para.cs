using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_para : MonoBehaviour
{
    public int x;
    public int y;
    Rigidbody2D playerRB;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        dir(new Vector2(x,y));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dir(Vector2 dir)
    {
        playerRB.velocity = dir.normalized * 10;
    }
}
