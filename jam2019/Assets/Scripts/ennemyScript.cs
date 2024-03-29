﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemyScript : MonoBehaviour
{
    private WeaponProjectile[] weapons;

    bool canAttack = false;

    void Awake()
    {
        // Retrieve the weapon only once
        weapons = GetComponentsInChildren<WeaponProjectile>();
    }

    void Update()
    {
        if (canAttack)
        {
            foreach (WeaponProjectile weapon in weapons)
            {
                // Auto-fire
                if (weapon != null && weapon.CanAttack)
                {
                    weapon.Attack(true);
                }
            }
        }
    }

    public void StartAttacking()
    {
        canAttack = true;
    }
}
