using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class HealthScript : MonoBehaviour
{
    /// <summary>
    /// Total hitpoints
    /// </summary>
    public int hp = 1;
    public int scoreToGive = 10;
    public int touchDamage = 1;

    //Show Health in UI
    public Text countHealth;

    /// <summary>
    /// Enemy or player?
    /// </summary>
    public bool isEnemy = true;

    public GameObject particleEffect = null;

    public void Start()
    {
        
    }

    /// <summary>
    /// Inflicts damage and check if the object should be destroyed
    /// </summary>
    /// <param name="damageCount"></param>
    public void Damage(int damageCount)
    {
        Debug.Log("receiving damage");
        hp -= damageCount;

        if (particleEffect != null)
        {
            Instantiate(particleEffect, transform.position, transform.rotation);
        }
        if (hp <= 0)
        {
            // Dead!
            Destroy(gameObject);
            if (isEnemy)
            {
                FindObjectOfType<GameController>().gainPoints(scoreToGive);
                FindObjectOfType<GameController>().killCount += 1;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Is this a shot?
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            // Avoid friendly fire
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);

                // Destroy the shot
                Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthScript hp = collision.gameObject.GetComponent<HealthScript>();
        if (hp != null)
        {
            // Avoid friendly fire
            if (hp.isEnemy)
            {
                // Avoid friendly fire
                if (isEnemy != hp.isEnemy)
                {
                    Damage(hp.touchDamage);
                }
            }
        }
    }
}
