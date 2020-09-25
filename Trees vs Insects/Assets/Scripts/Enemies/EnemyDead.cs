using UnityEngine;
using UnityEngine.Events;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class EnemyDead : MonoBehaviour
    {
        [SerializeField]
        private readonly UnityEvent OnDie = null;

        private EnemyHealth enemyHealth;

        public void DestroyEnemy ()
        {
            EnemyList.List.Remove (gameObject);
            EnemyList.CheckEnemies ();

            Destroy (gameObject);

            OnDie?.Invoke ();
        }

        private void Awake ()
        {
            enemyHealth = GetComponentInChildren<EnemyHealth> ();
        }

        private void OnDisable ()
        {
            enemyHealth.OnDead -= DestroyEnemy;
        }

        private void OnEnable ()
        {
            EnemyList.List.Add (gameObject);

            enemyHealth.OnDead += DestroyEnemy;
        }
    }
}