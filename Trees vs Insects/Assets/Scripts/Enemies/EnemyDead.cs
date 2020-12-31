using UnityEngine;
using UnityEngine.Events;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class EnemyDead : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent OnDie = null;

        private EnemyHealth[] enemyHealth;

        public void DestroyEnemy ()
        {
            OnDie?.Invoke ();
        }

        private void Awake ()
        {
            enemyHealth = GetComponentsInChildren<EnemyHealth> ();
        }

        private void OnDisable ()
        {
            foreach (EnemyHealth health in enemyHealth)
                health.OnDead -= DestroyEnemy;
        }

        private void OnEnable ()
        {
            foreach (EnemyHealth health in enemyHealth)
                health.OnDead += DestroyEnemy;
        }
    }
}