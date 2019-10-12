using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civil : MonoBehaviour
{

    public float speed;

    private Transform target;
    private Transform targetFeet;
    private Transform myFeet;

    // Start is called before the first frame update
    void Start()
    {
        myFeet = transform.Find("Feet");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        targetFeet = target.Find("Feet");
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if(Vector2.Distance(myFeet.position, targetFeet.position) > 2)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetFeet.position.x, target.position.y), speed * Time.deltaTime);
            }
        }
    }
}
