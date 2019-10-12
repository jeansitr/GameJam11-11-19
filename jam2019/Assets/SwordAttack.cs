using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public int damage;
    //public GameObject damageNumber;
    public GameObject damageBurst;

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Is this a shot?
        EnemyScript enemy = otherCollider.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            Instantiate(damageBurst, transform.position, transform.rotation);
            Destroy(enemy.gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col);
        Instantiate(damageBurst, transform.position, transform.rotation);
    }
}
