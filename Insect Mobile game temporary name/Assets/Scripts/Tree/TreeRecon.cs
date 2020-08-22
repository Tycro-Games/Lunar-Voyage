using UnityEngine;

public class TreeRecon : MonoBehaviour
{
    [SerializeField]
    private float radius = 5.0f;
    [SerializeField]
    private LayerMask enemies = 0;

    public Collider CheckSorounding()
    {
        Collider[] colliders = new Collider[1];
        int count = Physics.OverlapSphereNonAlloc(transform.position, radius, colliders, enemies);
        if (count > 0)
        {
            return colliders[0];
        }
        return null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
