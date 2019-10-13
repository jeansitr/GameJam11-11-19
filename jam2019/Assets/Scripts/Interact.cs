using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    CircleCollider2D detection;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        detection = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.JoystickButton3) || Input.GetKey(KeyCode.JoystickButton2))
        {
            detection.enabled = true;
        }
        else
        {
            detection.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Civil civil = collision.GetComponent<Civil>();

        if (civil != null)
        {
            if (civil.target == null)
            {
                civil.target = player;
                civil.Follow(player);
                collision.enabled = false;
            }
        }
    }
}