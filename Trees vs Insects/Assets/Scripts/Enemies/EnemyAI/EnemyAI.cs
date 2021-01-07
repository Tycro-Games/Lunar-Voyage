using Bogadanul.Assets.Scripts.Player;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class EnemyAI : MonoBehaviour
    {
        private EnemyHealth enemyHP;

        public void TakeDamage (int dg)
        {
            enemyHP.TakeDamage (dg);
        }

        private void Start ()
        {
            enemyHP = GetComponent<EnemyHealth> ();
        }
    }
}