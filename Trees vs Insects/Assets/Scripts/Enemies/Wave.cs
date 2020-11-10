using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    [CreateAssetMenu (fileName = "Wave", menuName = "Create/new wave", order = 0)]
    public class Wave : ScriptableObject
    {
        public EnemySpawnable[] enemies;

        [Range (1, 360)]
        public float duration;

        [Range (0, 360)]
        public float durationBetweenEnemies;

        [Range (1, 100)]
        public int weight;
    }
}