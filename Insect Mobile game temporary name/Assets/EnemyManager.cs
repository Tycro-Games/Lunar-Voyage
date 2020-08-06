using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static Dictionary<TracePath, Pathfinding> pathfindings = new Dictionary<TracePath, Pathfinding> ();

    public static EnemyManager enemyManager;


    public static bool hasPath;
    private void Awake ()
    {
        pathfindings = new Dictionary<TracePath, Pathfinding> ();
    }
    private void Start ()
    {


        hasPath = true;

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
        hasPath = true;
        foreach (var path in pathfindings.Keys)
        {
            pathfindings[path].FindPath ();
            hasPath = pathfindings[path].FindPath (hasPath);
            if(!hasPath)
            {

                return;
            }
        }



    }
}
