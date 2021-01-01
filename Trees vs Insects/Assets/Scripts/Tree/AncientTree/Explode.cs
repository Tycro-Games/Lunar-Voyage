using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class Explode : MonoBehaviour
    {
        [SerializeField]
        private float range = 6.0f;

        [SerializeField]
        private int DAMAGE = 100000;

        [SerializeField]
        private LayerMask enemies = 0;

        public void Boom ()
        {
            Collider[] colliders = new Collider[256];
            int count = Physics.OverlapSphereNonAlloc (transform.position, range, colliders, enemies);

            if (count != 0)
            {
                for (int i = 0; i < count; i++)
                {
                    colliders[i].GetComponent<EnemyAI> ().TakeDamage (DAMAGE);
                }
            }
        }

        private void OnDrawGizmosSelected ()
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere (transform.position, range);
        }
    }
}