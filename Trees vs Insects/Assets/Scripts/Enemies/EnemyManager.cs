using Bogadanul.Assets.Scripts.Player;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public static class EnemyManager
    {
        public static bool hasPath;
        public static Dictionary<TracePathCheck, Pathfinding> pathfindings = new Dictionary<TracePathCheck, Pathfinding> ();

        public static bool CheckForNullPaths ()
        {
            if (pathfindings == null)
                return true;
            else
                return false;
        }

        public static void CheckSpace ()
        {
            if (CheckForNullPaths ())
                return;
            HashSet<Node> allPaths = new HashSet<Node> ();
            foreach (TracePathCheck path in pathfindings.Keys)
            {
                if (path == null)
                    continue;

                hasPath = pathfindings[path].FindPath ();
                allPaths.UnionWith (path.PathNoEnds ());
                if (!hasPath)
                {
                    Debug.Log ("not enough space");
                    return;
                }
            }
            DisplayPathManager.AddPaths (allPaths);
        }
    }
}