using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

/// <summary>
/// Launch projectile
/// </summary>
public class WeaponProjectile : MonoBehaviour
{
    //--------------------------------
    // 1 - Designer variables
    //--------------------------------

    //Sons
    AudioSource audiolanceProjectile;
    public AudioClip lance;

    /// <summary>
    /// Projectile prefab for shooting
    /// </summary>
    public Transform shotPrefab;
    public Transform angleLookingAt;

    /// <summary>
    /// Cooldown in seconds between two shots
    /// </summary>
    public float shootingRate = 0.25f;

    //--------------------------------
    // 2 - Cooldown
    //--------------------------------

    private float shootCooldown;

    void Start()
    {
        audiolanceProjectile = GetComponent<AudioSource>();
        shootCooldown = 0f;
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    //--------------------------------
    // 3 - Shooting from another script
    //--------------------------------

    /// <summary>
    /// Create a new projectile if possible
    /// </summary>
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            /* // Create a new shot
             var shotTransform = Instantiate(shotPrefab) as Transform;

             // Assign position
             shotTransform.position = transform.position;*/
            
            Transform shotTransform = Instantiate(shotPrefab, transform.position + 1.0f * angleLookingAt.forward, new Quaternion(angleLookingAt.eulerAngles.x, 0, angleLookingAt.eulerAngles.z, 0));

            // The is enemy property
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null)
            {
                audiolanceProjectile.PlayOneShot(lance, 0.7F);
                shot.isEnemyShot = isEnemy;
            }

            // Make the weapon shot always towards it
            MoveScriptTest move = shotTransform.gameObject.GetComponent<MoveScriptTest>();
            if (move != null)
            {
                move.direction = angleLookingAt.forward; // towards in 2D space is the right of the sprite
            }
        }
    }

    /// <summary>
    /// Is the weapon ready to create a new projectile?
    /// </summary>
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}
