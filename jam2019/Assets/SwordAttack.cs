using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public int damage;
    //public GameObject damageNumber;
    public GameObject damageBurst;

    public AudioClip coupEpee;

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Debug.Log("allo");
        HealthScript hp = otherCollider.gameObject.GetComponent<HealthScript>();
        source.PlayOneShot(shootSound, vol);
        source = GetComponent<AudioSource>();
        if (hp != null)
        {
            // Avoid friendly fire
            if (hp.isEnemy)
            {
                hp.Damage(damage);
            }
        }
    }
    private AudioSource coupEpee;

}
