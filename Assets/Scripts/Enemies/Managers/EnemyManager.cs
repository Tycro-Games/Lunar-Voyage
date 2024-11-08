﻿using Bogadanul.Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public static class EnemyManager
    {
        public static bool hasPath;
        public static Dictionary<TracePathCheck, Pathfinding> pathfindings = new Dictionary<TracePathCheck, Pathfinding>();
        public static Action<List<Node>> OnNoSpace;

        public static Gridmanager grid = null;
        public static Action<bool> OnEnemySet;
        public static bool CheckForNullPaths()

        {
            if (pathfindings == null)
                return true;
            else
                return false;
        }

       

        public static void CheckSpaceForOnlyPaths(Node n)
        {
            if (CheckForNullPaths())
                return;
            hasPath = false;
            foreach (TracePathCheck path in pathfindings.Keys.ToList())
            {
                if (CheckPath(path))
                    continue;

                hasPath = pathfindings[path].HasPath(n);

                if (!hasPath)
                {
                    Debug.Log("No path");
                    return;
                }
            }
        }

        

        public static void UpdateGrid()
        {
            grid.UpdateGrid();
        }

        public static void SetSpace(bool remove = false)
        {
            
            if (CheckForNullPaths())
                return;
            
            foreach (TracePathCheck path in pathfindings.Keys.ToList())
            {
                if (CheckPath(path))
                {
                    continue;
                }
                pathfindings[path].FindPath(remove);
            }
            OnEnemySet?.Invoke(true);
        }

        private static bool CheckPath(TracePathCheck path)
        {
            bool NoPath = path == null;
            if (NoPath)
                pathfindings.Remove(path);
            return NoPath;
        }
    }
}