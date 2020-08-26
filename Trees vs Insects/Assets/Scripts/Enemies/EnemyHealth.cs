using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public event Action OnDead;
    [SerializeField]
    private int health = 0;
    public void TakeDamage(int dg)
    {
        health -= dg;
        if (health <= 0)
        {
            OnDead?.Invoke();
        }

    }

}
