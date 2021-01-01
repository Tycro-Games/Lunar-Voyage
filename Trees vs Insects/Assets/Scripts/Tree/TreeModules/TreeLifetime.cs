using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class TreeLifetime : MonoBehaviour
    {
        private DestroyTree destroy;

        [SerializeField]
        private float lifetime = 0;

        public void IsTooOld (float time)
        {
            lifetime -= time;
            if (lifetime <= 0)
            {
                destroy.DestroyTheTree ();
            }
        }

        private void Start ()
        {
            destroy = GetComponent<DestroyTree> ();
        }
    }
}