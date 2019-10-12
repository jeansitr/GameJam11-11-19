/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

    public int damage;
    public GameObject damageNumber;
    public GameObject damageBurst;

    void OnCollisionEnter2D(Collision2D other)
    {
        Instantiate(damageBurst, transform.position, transform.rotation);
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().Hit(damage);
            var clone = (GameObject)Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
            if (other.gameObject.GetComponent<EnemyHealth>().invincibility)
            {
                clone.GetComponent<FloatingNumbers>().damageNumber = 0;
            }
            else
            {
                clone.GetComponent<FloatingNumbers>().damageNumber = damage;
            }
            
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
*/