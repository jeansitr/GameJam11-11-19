using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanScript : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement playermv = FindObjectOfType<PlayerMovement>();
        player = playermv.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player.transform.Find("Feet"));
        }
    }
}
