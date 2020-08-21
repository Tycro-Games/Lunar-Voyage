using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager
{
    public static Dictionary<TracePathCheck, Pathfinding> pathfindings = new Dictionary<TracePathCheck, Pathfinding>();

    public static EnemyManager enemyManager;
    public static bool hasPath;

    public static bool CheckForNullPaths()
    {
        if (pathfindings == null)
            return true;
        else
            return false;
    }
    public static void CheckSpace()
    {
        if (CheckForNullPaths())
            return;

        hasPath = true;
        foreach (var path in pathfindings.Keys)
        {
            hasPath = pathfindings[path].FindPath();
            if (!hasPath)
            {
                return;
            }
        }
    }
}
