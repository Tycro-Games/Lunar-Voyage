using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static Dictionary<TracePath,Pathfinding> pathfindings = new Dictionary<TracePath, Pathfinding>();

    public static EnemyManager enemyManager;

    public static bool hasPath = true;
    private void Start ()
    {
        if (enemyManager == null)
            enemyManager = this;
        else
            Destroy (gameObject);
    }
    private void OnEnable ()
    {
        TreePlacer.OnPlaceTree += CheckSpace;
    }
    private void OnDisable ()
    {
        TreePlacer.OnPlaceTree -= CheckSpace;
    }
    public void CheckSpace ()
    {
        int pathCount = 0;
        TracePath path1 = null;
        foreach (var path in pathfindings.Keys)
        {
            if (path.SetPath.Count > pathCount)
            {
                path1 = path;
                pathCount = path.SetPath.Count;             
            }
            pathfindings[path].FindPath ();
        }

        hasPath = path1.GetComponent<Pathfinding> ().FindPath (hasPath);
        Debug.Log (hasPath);
    }
}
