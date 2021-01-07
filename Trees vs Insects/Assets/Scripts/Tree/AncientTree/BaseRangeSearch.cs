using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class BaseRangeSearch : MonoBehaviour
    {
        [SerializeField]
        protected float range = 6.0f;

        [SerializeField]
        protected LayerMask enemies = 0;

        private void OnDrawGizmosSelected ()
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere (transform.position, range);
        }
    }
}