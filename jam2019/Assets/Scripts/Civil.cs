using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Civil : MonoBehaviour
{

    public float speed;
    public Transform target;
    private Transform targetFeet;
    private Transform myFeet;
    private Animator anim;
    private int followDistance = 2;

    AudioSource audioSuivre;
    public AudioClip suivre;

    // Start is called before the first frame update
    void Start()
    {
        myFeet = transform.Find("Feet");
        anim = GetComponent<Animator>();
        audioSuivre = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if(Vector2.Distance(myFeet.position, targetFeet.position) > followDistance)
            {
                anim.SetBool("moving", true);
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetFeet.position.x, target.position.y), speed * Time.deltaTime);
                float adjacent = transform.position.x - target.transform.position.x;
                float oppose = target.transform.position.y - transform.position.y;

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
            else
            {
                anim.SetBool("moving", false);
            }
        }
    }

    public void Follow(Transform newTarget)
    {
        audioSuivre.PlayOneShot(suivre, 0.7F);
        target = newTarget;
        targetFeet = target.Find("Feet");
        GetComponent<Collider2D>().enabled = false;
        PlayerMovement player = target.GetComponent<PlayerMovement>();
        player.followingCivil++;
        followDistance = 2 * player.followingCivil;
    }
}
