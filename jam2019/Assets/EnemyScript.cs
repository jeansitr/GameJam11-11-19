using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float moveSpeed;
    public float MinDist = 5f;
    public float MaxDist = 10f;

    private Animator anim;
    private Rigidbody2D myRigidbody;
    public GameObject PlayerFeet;

    private bool moving;

    private float timeBetweenMove;
    public float timeBetweenMoveOriginal;
    private float timeBetweenMoveCounter;

    public float timeToMove;
    private float timeToMoveCounter;

    private Vector3 moveDirection;

    public float waitToReload;
    private PlayerMovement player;
    public bool detecterJoueur;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();

        //timeBetweenMoveCounter = timeBetweenMove;
        //timeToMoveCounter = timeToMove;
        timeBetweenMove = timeBetweenMoveOriginal;
        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
        anim.SetBool("moving", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = moveDirection;

            if (timeToMoveCounter < 0f)
            {
                moving = false;
                //timeBetweenMoveCounter = timeBetweenMove;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;
            if (timeBetweenMoveCounter < 0f)
            {
                moving = true;
                //timeToMoveCounter = timeToMove;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

                if (Vector3.Distance(player.transform.position, transform.position) < 10f && detecterJoueur)
                {
                    timeBetweenMove = 0.5f;
                    moveDirection = player.transform.position - transform.position;
                }
                else
                {
                    timeBetweenMove = timeBetweenMoveOriginal;
                    moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
                }

                /*if (moveDirection.x <= 0f)
                {
                    anim.SetFloat("moveX", -1f);
                }
                else
                {
                    anim.SetFloat("moveX", 1f);
                }*/
            }
        }
        if (Vector2.Distance(transform.position, player.gameObject.transform.position) >= MinDist)
        {
            detecterJoueur = true;
            Debug.Log("Joueur Détecté");
        }

        float adjacent = transform.position.x - player.transform.position.x;
        float oppose = player.transform.position.y - transform.position.y;

        float angle = Mathf.Atan2(oppose, adjacent);
        angle = ((angle * 180) / Mathf.PI);


        if (angle > -45f && angle <= 45f)
        {
            anim.SetFloat("moveX", -1);
            anim.SetFloat("moveY", 0);
        }
        else if (angle > 45f && angle <= 135f)
        {
            anim.SetFloat("moveX", 0);
            anim.SetFloat("moveY", 1);
        }
        else if (angle > 135f || angle <= -135f)
        {
            anim.SetFloat("moveX", 1);
            anim.SetFloat("moveY", 0);
        }
        else
        {
            anim.SetFloat("moveX", 0);
            anim.SetFloat("moveY", -1);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "PlayerController")
        {
            Debug.Log("Player dead");
        }
    }

    public void Die()
    {
        Debug.Log("Enemy dead");
    }

    public void WakeUp()
    {
        detecterJoueur = true;
    }

}