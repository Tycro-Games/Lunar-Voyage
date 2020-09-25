using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class TreeRecon : MonoBehaviour
    {
        private BoxCollider[] colliders = new BoxCollider[10];

        [SerializeField]
        private LayerMask enemies = 0;

        [SerializeField]
        private float radius = 5.0f;

        private Vector3 radiusVect;

        public bool CheckDist (BoxCollider col)
        {
            if (radius >= dist (col.transform.position))
                return true;
            return false;
        }

        public BoxCollider CheckSorounding ()
        {
            int count = Physics.OverlapBoxNonAlloc (transform.position, radiusVect, colliders, Quaternion.identity, enemies);
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

        private void Awake ()
        {
            radiusVect = new Vector3 (radius / 2, radius / 2, 1);
        }

        private float dist (Vector3 col)
        {
            Vector2 dist = transform.position - col;
            return dist.sqrMagnitude;
        }

        private void OnDrawGizmosSelected ()
        {
            Gizmos.DrawWireCube (transform.position, new Vector3 (radius, radius));
        }
    }
}