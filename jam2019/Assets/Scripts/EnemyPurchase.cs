using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPurchase : MonoBehaviour
{
    public float speed;

    public Transform target;
    private Transform targetFeet;
    public Transform myFeet;

    public Transform player;
    public float MinDist;
    bool detecterJoueur = false;
    ennemyScript enemyScript;
    Animator anim;
    PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        myFeet = transform.Find("Feet");
        enemyScript = GetComponent<ennemyScript>();
        anim = GetComponent<Animator>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if (Vector2.Distance(myFeet.position, targetFeet.position) > 2)
            {
                Vector2 movement = Vector2.MoveTowards(transform.position, new Vector2(targetFeet.position.x, target.position.y), speed * Time.deltaTime);
                transform.position = movement;

                float adjacent = transform.position.x - target.position.x;
                float oppose = target.position.y - transform.position.y;

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
                    else if(angle > 135f || angle <= -135f)
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
        }

        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.gameObject.transform.position) <= MinDist && detecterJoueur == false)
            {
                detecterJoueur = true;
                Follow(player);
                anim.SetBool("moving", true);
                enemyScript.StartAttacking();
            }
        }
        else
        {
            player = playerMovement.gameObject.transform;
        }
    }

    public void Follow(Transform newTarget)
    {
        target = GameObject.Find("PlayerController").GetComponent<Transform>();
        targetFeet = target.Find("Feet");
    }
}
