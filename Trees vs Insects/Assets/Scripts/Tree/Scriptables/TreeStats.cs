using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    [CreateAssetMenu (fileName = "new tree", menuName = "Create/ new tree")]
    public class TreeStats : ScriptableObject
    {
        [SerializeField]
        private float Lifetime = 0;

        public float GetLifetime
        {
            get => Lifetime;
        }
    }
}