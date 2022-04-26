using Bogadanul.Assets.Scripts.Player;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        private Gridmanager grid = null;

        private Pathfinding pathfinding;

        [SerializeField]
        private Transform target = null;

        public void Spawn (GameObject enemyPrefab)
        {
            GameObject enemy = Instantiate (enemyPrefab, transform.position, Quaternion.identity, transform);

            foreach (IEnemyAI enemyPath in enemy.GetComponentsInChildren<IEnemyAI> ())
            {
                enemyPath.Init (target, grid);
            }
        }

        private void Awake ()
        {
            grid = FindObjectOfType<Gridmanager> ();

            pathfinding = GetComponent<Pathfinding> ();

            pathfinding.Init (target, grid);
        }
    }
}