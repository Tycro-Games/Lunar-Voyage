using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    [CreateAssetMenu(fileName = "1", menuName = "Create/new wave", order = 0)]
    public class Wave : ScriptableObject
    {
        public EnemySpawnable[] enemies;

        [Range(0, 360)]
        public float durationBetweenEnemies;

        [Range(1, 100)]
        public int weight;

        public int CountSpawners = 10;
        // public float durationBetweenWaves;
    }
}