using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : EnemyAIInheritence
{
    private int health = 0;

    void Start()
    {
        health = enemyAI.EnemyCommon.GetHealth;
    }
    public void Die(int dg)
    {
        health -= dg;
        if (health <= 0)
        {
            Debug.Log(gameObject.name);
            Destroy(gameObject);
        }

    }

}
