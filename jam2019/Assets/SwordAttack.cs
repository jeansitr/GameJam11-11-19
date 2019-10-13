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
        HealthScript hp = otherCollider.gameObject.GetComponent<HealthScript>();
        if (hp != null)
        {
            // Avoid friendly fire
            if (hp.isEnemy)
            {
                hp.Damage(damage);
            }
        }
    }
}
