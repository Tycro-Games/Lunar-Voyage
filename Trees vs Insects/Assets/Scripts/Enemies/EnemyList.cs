using System;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public static class EnemyList
    {
        public static event Action OnNoEnemies;

        public static List<GameObject> List { get; set; } = new List<GameObject> ();

        public static void CheckEnemies ()
        {
            if (List.Count == 0)
                OnNoEnemies?.Invoke ();
        }
    }
}