using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerController : MonoBehaviour
{
    public Rigidbody2D body;
    SpriteRenderer playerRenderer;
    Animator anim;

    Vector2 movement;
    float moveLimiter = 0.7f;
    bool facingRight = true;

    public float runSpeed = 20.0f;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(GameManager.IsInCinematic == false)
        {
            movement.x = Input.GetAxisRaw("Horizontal"); // -1 is left
            movement.y = Input.GetAxisRaw("Vertical"); // -1 is down
            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
            anim.SetFloat("Speed", movement.sqrMagnitude);
        }
        else{
            movement.x=0;
            movement.y=0;
        }
        // Gives a value between -1 and 1
    }

    void FixedUpdate()
    {
        if (movement.x < 0 && facingRight) // Check for diagonal movement
        {
            flip();
        }
        if (movement.x > 0 && !facingRight)
        {
            flip();
        }

        body.velocity = movement * runSpeed;
    }

    void flip()
    {
        facingRight = !facingRight; // On change la valeur du boolen facing right par son contraire, repr�sentant la direction du personnage
        playerRenderer.flipX = !playerRenderer.flipX; // M�me chose ici pour que notre flipx et facingRight soient en phase
    }
}
