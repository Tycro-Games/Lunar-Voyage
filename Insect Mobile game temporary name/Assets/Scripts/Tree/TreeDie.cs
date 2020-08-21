using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDie : TreeInherit
{
    float lifetime = 0;
    private void Start()
    {
        lifetime = treeAI.GetTreeStats.GetLifetime;
    }
    public void Die(float time)
    {
        lifetime -= time;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
            EnemyManager.CheckSpace();

        }
    }
}
