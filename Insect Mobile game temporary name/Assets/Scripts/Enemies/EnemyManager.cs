using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static Dictionary<TracePath, Pathfinding> pathfindings = new Dictionary<TracePath, Pathfinding>();

    public static EnemyManager enemyManager;
    public static bool hasPath;
    private void Awake()
    {
        pathfindings = new Dictionary<TracePath, Pathfinding>();
    }
    private void Start()
    {
        hasPath = true;

        if (enemyManager == null)
            enemyManager = this;
        else
            Destroy(gameObject);
    }

    public static void CheckSpace()
    {
        if (pathfindings == null)
            return;

        hasPath = true;
        foreach (var path in pathfindings.Keys)
        {
            hasPath = pathfindings[path].FindPath(hasPath);
            if (!hasPath)
            {
                return;
            }
        }



    }
}
