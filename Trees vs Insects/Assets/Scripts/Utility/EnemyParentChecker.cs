using Bogadanul.Assets.Scripts.Enemies;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Utility
{
    public class EnemyParentChecker : MonoBehaviour
    {
        private Transform child = null;
        private EnemyHealth[] enemyHealth;
        public void CheckChildren ()
        {
            if (child.childCount == 1)
            {
                Destroy (gameObject);
            }
        }
        private void OnDisable ()
        {
            foreach (EnemyHealth health in enemyHealth)
                health.OnDead -= CheckChildren;
        }
        
        private void Start ()
        {
            enemyHealth = GetComponentsInChildren<EnemyHealth> ();
            foreach (EnemyHealth health in enemyHealth)
                health.OnDead += CheckChildren;
            child = transform.GetChild (0);
        }

        
    }
}