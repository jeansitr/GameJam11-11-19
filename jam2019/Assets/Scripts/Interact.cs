using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Interact : MonoBehaviour
{
    CircleCollider2D detection;
    public Transform player;
    public GameController gameController;
    public int numberOfFollowers = 0;
    List<Civil> listFollower = new List<Civil>();

    // Start is called before the first frame update
    void Start()
    {
        detection = GetComponent<CircleCollider2D>();
        gameController = FindObjectOfType<GameController>();
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
        if (collision.tag == "Portal")
        {
            Portal portal = collision.GetComponent<Portal>();

            if (portal != null)
            {
                gameController.NextLevel();
            }
        }

        if (collision.tag == "Civil")
        {
            Civil civil = collision.GetComponent<Civil>();

            if (civil != null)
            {
                if (civil.target == null)
                {
                    if (!listFollower.Contains(civil))
                    {
                        civil.target = player;
                        civil.Follow(player);
                        listFollower.Add(civil);
                        gameController.AddFollower();
                        collision.enabled = false;
                    }
                }
            }
        }
    }
}