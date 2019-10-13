using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject Target;
    public GameObject player;

    private void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            Vector3 newPos = new Vector3(Target.transform.position.x, Target.transform.position.y - (player.transform.Find("Feet").position.y - player.transform.position.y), 0);
            player.transform.position = newPos;

            GameObject[] civils = GameObject.FindGameObjectsWithTag("Civil");
            foreach(GameObject civ in civils)
            {
                if (civ.GetComponent<Civil>().target != null)
                {
                    civ.transform.position = newPos;
                }
            }
        }
    }
}
