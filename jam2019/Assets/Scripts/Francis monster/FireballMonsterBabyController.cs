/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireballMonsterBabyController : MonoBehaviour {

    private RoomController roomController;
    public GameObject coin;
    public float moveSpeed;

    private Animator anim;
    private Rigidbody2D myRigidbody;

    private bool moving;

    private float timeBetweenMove;
    public float timeBetweenMoveOriginal;
    private float timeBetweenMoveCounter;

    public float timeToMove;
    private float timeToMoveCounter;

    private Vector3 moveDirection;

    public float waitToReload;
    private bool reloading;
    private PlayerController player;
    public bool detecterJoueur;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
        roomController = FindObjectOfType<RoomController>();

        //timeBetweenMoveCounter = timeBetweenMove;
        //timeToMoveCounter = timeToMove;
        timeBetweenMove = timeBetweenMoveOriginal;
        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
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

                if (Vector3.Distance(player.transform.position, transform.position) < 5f && detecterJoueur)
                {
                    timeBetweenMove = 0.5f;
                    moveDirection = player.transform.position - transform.position;
                }
                else
                {
                    timeBetweenMove = timeBetweenMoveOriginal;
                    moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
                }

                if (moveDirection.x <= 0f)
                {
                    anim.SetFloat("moveX", -1f);
                }
                else
                {
                    anim.SetFloat("moveX", 1f);
                }
            }
        }

        if (reloading)
        {
            waitToReload -= Time.deltaTime;
            if (waitToReload < 0f)
            {
                SceneManager.LoadScene("Main");
                player.Revive();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            player.Die();
            reloading = true;
        }
    }

    public void Die()
    {
        Instantiate(coin, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Destroy(gameObject);
        roomController.EnemyDead();
    }

    public void WakeUp()
    {
        detecterJoueur = true;
    }
}
*/