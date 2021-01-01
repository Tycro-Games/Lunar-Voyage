using System;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class EnemyListChecker : MonoBehaviour
    {
        public event Action OnNoEnemies;

        public void StartCheckingForEnemies ()
        {
            CheckList ();
        }

        private void CheckList ()
        {
            OnNoEnemies?.Invoke ();
        }

        private void OnDisable ()
        {
            EnemyList.OnNoEnemies -= CheckList;
        }

        private void OnEnable ()
        {
            EnemyList.OnNoEnemies += CheckList;
        }
    }
}