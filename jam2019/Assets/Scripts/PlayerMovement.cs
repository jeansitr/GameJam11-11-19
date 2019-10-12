using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;                //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.

    private Animator anim;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float moveX = 0;
        float moveY = 0;

        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveY = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1;
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
        {
            moveX = 0;
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            moveY = 0;
        }

        //anim.SetFloat("moveX", Input.GetAxis("Horizontal"));
        //anim.SetFloat("moveY", Input.GetAxis("Vertical"));
        anim.SetFloat("moveY", moveY);
        anim.SetFloat("moveX", moveX);
    }
    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rb2d.velocity = new Vector2(x * speed, y * speed);
    }
}
