using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectEnemy : MonoBehaviour {

    public List<GameObject> enemyList = new List<GameObject>();
    public bool roomCompleted;
    private bool alreadyIn;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!roomCompleted)
        {
            if (collision.tag == "Enemy")
            {
                alreadyIn = false;
                foreach (GameObject gameObject in enemyList)
                {
                    if (gameObject == collision.gameObject)
                    {
                        alreadyIn = true;
                    }
                }
                if (!alreadyIn)
                {
                    enemyList.Add(collision.gameObject);
                }
            }
        }
    }
}