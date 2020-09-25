using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    [CreateAssetMenu (fileName = "new enemy common stats", menuName = "Create/new enemy")]
    public class EnemyCommon : ScriptableObject
    {
        [SerializeField]
        private readonly int damage = 1;

        [SerializeField]
        private readonly int health = 10;

        public int Getdamage
        {
            get => damage;
        }

        public int GetHealth
        {
            get => health;
        }
    }
}