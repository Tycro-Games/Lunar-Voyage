using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class TreeRecon : MonoBehaviour, ITreeRecon
    {
        private BoxCollider[] colliders = new BoxCollider[10];

        [SerializeField]
        private LayerMask enemies = 0;

        [SerializeField]
        private float radius = 5.0f;

        public BoxCollider CheckSorounding ()
        {
            int count = Physics.OverlapSphereNonAlloc (transform.position, radius, colliders, enemies);
            if (count > 0)
            {
                BoxCollider col = colliders[0];

                float currentDist = dist (col.transform.position);
                foreach (BoxCollider c in colliders)
                {
                    if (c == null)
                        continue;

                    float Dist = dist (c.transform.position);
                    if (Dist < currentDist)
                    {
                        col = c;
                        currentDist = Dist;
                    }
                }
                return col;
            }
            return null;
        }

        public bool CheckDist (BoxCollider col)
        {
            if (radius * radius >= dist (col.transform.position))
                return true;
            return false;
        }

        private float dist (Vector3 col)
        {
            Vector2 dist = transform.position - col;
            return dist.sqrMagnitude;
        }

        private void OnDrawGizmosSelected ()
        {
            Gizmos.DrawWireSphere (transform.position, radius);
        }
    }
}