using System.Linq;
using UnityEngine;
public class TreeRecon : MonoBehaviour
{
    [SerializeField]
    private float radius = 5.0f;
    [SerializeField]
    private LayerMask enemies = 0;
    private Collider[] colliders = new Collider[10];
    public Collider CheckSorounding()
    {

        int count = Physics.OverlapSphereNonAlloc(transform.position, radius, colliders, enemies);
        if (count > 0)
        {
            Collider col = colliders[0];

            float currentDist = dist(col.transform.position);
            foreach (Collider c in colliders)
            {
                if (c == null)
                    continue;

                float Dist = dist(c.transform.position);
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
    private float dist(Vector3 col)
    {
        return (transform.position - col).sqrMagnitude;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);

    }
}
