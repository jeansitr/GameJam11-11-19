﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class HealthScript : MonoBehaviour
{
    AudioSource audioTakeDamage;
    public AudioClip takeDamage;

    AudioSource audioMort;
    public AudioClip mort;

    /// <summary>
    /// Total hitpoints
    /// </summary>
    public int hp = 1;
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
        audioTakeDamage = GetComponent<AudioSource>();
        audioMort = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Inflicts damage and check if the object should be destroyed
    /// </summary>
    /// <param name="damageCount"></param>
    public void Damage(int damageCount)
    {
        hp -= damageCount;
        audioTakeDamage.PlayOneShot(takeDamage, 0.7F);

        if (particleEffect != null)
        {
            Instantiate(particleEffect, transform.position, transform.rotation);
        }
        if (hp <= 0)
        {
            audioMort.PlayOneShot(mort, 0.7F);

            // Dead!
            Destroy(gameObject);
            
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
