using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float duration;    //the max time of a walking session (set to ten)
    public float elapsedTime = 0f; //time since started walk
    public float wait = 0f; //wait this much time
    public float waitTime = 0f; //waited this much time

    float randomX;  //randomly go this X direction
    float randomY;  //randomly go this Z direction

    bool move = true; //start moving

    void Start()
    {
        randomX = Random.Range(-3, 3);
        randomY = Random.Range(-3, 3);
    }

    void Update()
    {



        //Debug.Log (elapsedTime);

        if (elapsedTime < duration && move)
        {
            //if its moving and didn't move too much
            transform.Translate(new Vector3(randomX, randomY, 0) * Time.deltaTime);
            elapsedTime += Time.deltaTime;

        }
        else
        {
            //do not move and start waiting for random time
            move = false;
            wait = Random.Range(5, 10);
            waitTime = 0f;
        }

        if (waitTime < wait && !move)
        {
            //you are waiting
            waitTime += Time.deltaTime;


        }
        else
        {
            //done waiting. Move to these random directions
            move = true;
            randomX = Random.Range(-3, 3);
            randomY = Random.Range(-3, 3);
        }
    }




}