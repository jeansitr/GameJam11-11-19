using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;                //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.

    public Animator anim;

    public GameObject sword;

    public float joySens = 0.7f;
    public int followingCivil = 0;

    float moveX = 0;
    float moveY = 0;
    float lastMoveX = 0;
    float lastMoveY = -1;
    bool moving = false;
    bool attacking = false;


    public float timeBetweenAttack;
    float timeLeft;
    bool hasAttacked = false;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        timeLeft = timeBetweenAttack;
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        moveX = 0;
        moveY = 0;

        moving = false;

        /*if (Input.GetKey(KeyCode.D))
        {
            moveX = 1;
            lastMoveX = 1;
            lastMoveY = 0;
            moving = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1;
            lastMoveX = -1;
            lastMoveY = 0;
            moving = true;
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveY = 1;
            lastMoveY = 1;
            lastMoveX = 0;
            moving = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1;
            lastMoveY = -1;
            lastMoveX = 0;
            moving = true;
        }*/

        if (Input.GetAxis("Horizontal") >= joySens)
        {
            moveX = 1;
            lastMoveX = 1;
            lastMoveY = 0;
            //moving = true;
        }

        if (Input.GetAxis("Horizontal") <= -joySens)
        {
            moveX = -1;
            lastMoveX = -1;
            lastMoveY = 0;
            //moving = true;
        }

        if (Input.GetAxis("Vertical") >= joySens)
        {
            moveY = 1;
            lastMoveY = 1;
            lastMoveX = 0;
            //moving = true;
        }

        if (Input.GetAxis("Vertical") <= -joySens)
        {
            moveY = -1;
            lastMoveY = -1;
            lastMoveX = 0;
            //moving = true;
        }

        if (Input.GetKey(KeyCode.JoystickButton1) /* && hasAttacked == false*/)
        {
            attacking = true;
            hasAttacked = true;
        }
        else
        {
            attacking = false;
        }

        /*if (hasAttacked)
        {
            
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                hasAttacked = false;
                timeLeft = timeBetweenAttack;
            }
        }*/
        
        //anim.SetFloat("moveX", Input.GetAxis("Horizontal"));
        //anim.SetFloat("moveY", Input.GetAxis("Vertical"));
        
        //anim.SetBool("moving", moving);
    }
    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        float x = 0;
        float y = 0;
        /*if (moving)
        {*/
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
        //}
        
        if ((x >= joySens || x <= -joySens) || ((y >= joySens || y <= -joySens)) || (y >= joySens || x <= -joySens) || (x >= joySens || y >= joySens) || (x >= joySens || y <= -joySens) || (y <= -joySens || x <= -joySens))
        {
            rb2d.velocity = new Vector2(x * speed, y * speed);
            moving = true;
        }
        else
        {
            rb2d.velocity = new Vector2(0 * speed, 0 * speed);
        }
        anim.SetBool("moving", moving);
        anim.SetBool("Attack", attacking);
        anim.SetFloat("moveY", moveY);
        anim.SetFloat("moveX", moveX);
        anim.SetFloat("lastMoveX", lastMoveX);
        anim.SetFloat("lastMoveY", lastMoveY);
    }
}
