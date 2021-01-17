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

            foreach (TracePathCheck path in pathfindings.Keys)
            {
                if (path == null)
                    continue;

                hasPath = pathfindings[path].HasPath ();

                if (!hasPath)
                {
                    Debug.Log ("not enough space");
                    return;
                }
            }
        }

        public static void SetSpace ()
        {
            if (CheckForNullPaths ())
                return;

            foreach (TracePathCheck path in pathfindings.Keys)
            {
                if (path == null)
                    continue;

                pathfindings[path].FindPath ();
            }
        }
    }
}