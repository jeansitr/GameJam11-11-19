using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject Target;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            player.transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y - (player.transform.Find("Feet").position.y - player.transform.position.y), 0);
        }
    }
}
