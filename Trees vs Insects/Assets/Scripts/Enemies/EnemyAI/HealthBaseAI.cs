using Bogadanul.Assets.Scripts.Player;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public abstract class HealthBaseAI : MonoBehaviour, IEnemyAI
    {
        protected EnemyHealth enemyHP = null;
        protected Pathfinding pathfinding = null;

        public virtual void TakeDamage (int dg)
        {
            enemyHP.TakeDamage (dg);
        }

        public virtual void Init (Transform Target, Gridmanager grid)
        {
            pathfinding = GetComponent<Pathfinding> ();

            pathfinding.Init (Target, grid);
        }

        protected virtual void Start ()
        {
            enemyHP = GetComponent<EnemyHealth> ();
        }
    }
}