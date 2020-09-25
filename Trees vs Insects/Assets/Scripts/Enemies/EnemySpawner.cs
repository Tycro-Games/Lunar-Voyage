using Bogadanul.Assets.Scripts.Grid;
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

            Pathfinding[] enemyPaths = enemy.GetComponentsInChildren<Pathfinding> ();
            foreach (Pathfinding enemyPath in enemyPaths)
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