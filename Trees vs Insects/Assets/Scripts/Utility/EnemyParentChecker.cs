using Bogadanul.Assets.Scripts.Enemies;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Utility
{
    public class EnemyParentChecker : MonoBehaviour
    {
        public void CheckChildren ()
        {
            if (transform.GetChild (0).childCount == 1)
            {//this is fucked up but if this is called that means the enemy will die so it s fine
                EnemyList.CheckEnemies ();
                EnemyList.List.Remove (gameObject);
                Destroy (gameObject);
            }
        }

        private void OnEnable ()
        {
            EnemyList.List.Add (gameObject);
        }
    }
}