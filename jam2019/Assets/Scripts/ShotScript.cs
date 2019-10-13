using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Projectile behavior
/// </summary>
public class ShotScript : MonoBehaviour
{
    // 1 - Designer variables

    /// <summary>
    /// Damage inflicted
    /// </summary>
    public int damage = 1;

    public int timeToDespawn = 3;

    /// <summary>
    /// Projectile damage player or enemies?
    /// </summary>
    public bool isEnemyShot = false;

    void Start()
    {
        // 2 - Limited time to live to avoid any leak
        Destroy(gameObject, timeToDespawn); 
    }
}
