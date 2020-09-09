using System;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyList
{
    private static List<GameObject> enemyList = new List<GameObject>();

    public static event Action OnNoEnemies;
    public static List<GameObject> List
    {

        get
        {
            return enemyList;
        }
        set
        {
            enemyList = value;
        }
    }
    public static void CheckEnemies()
    {
        if (enemyList.Count == 0)
            OnNoEnemies?.Invoke();
    }
}
