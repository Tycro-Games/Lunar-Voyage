using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager
{
    public static Dictionary<TracePathCheck, Pathfinding> pathfindings = new Dictionary<TracePathCheck, Pathfinding>();
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


        foreach (var path in pathfindings.Keys)
        {
            if (path == null)
                continue;

            hasPath = pathfindings[path].FindPath();

            if (!hasPath)
            {
                Debug.Log("not enough space");
                return;
            }
        }
    }
}
