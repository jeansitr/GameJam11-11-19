using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int maxHP;
    private int currentHP;
    public bool invincibility;

    private void Start()
    {
        currentHP = maxHP;
    }

    public void Hit(int damage)
    {
        if (!invincibility)
        {
            currentHP -= damage;
        }

        if (currentHP <= 0f)
        {
            gameObject.SendMessage("Die");
        }
    }

    public int CalculateHealth()
    {
        return currentHP / maxHP;
    }


    public int getCurrentHP()
    {
        return currentHP;
    }
}
