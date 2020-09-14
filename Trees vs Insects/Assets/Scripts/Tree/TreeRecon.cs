using System.Linq;
using UnityEngine;

public class TreeRecon : MonoBehaviour
{
    [SerializeField]
    private float radius = 5.0f;

    private Vector3 radiusVect;

    [SerializeField]
    private LayerMask enemies = 0;

    private BoxCollider[] colliders = new BoxCollider[10];

    private void Awake ()
    {
        radiusVect = new Vector3 (radius / 2, radius / 2, 1);
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

    public bool CheckDist (BoxCollider col)
    {
        if (radius >= dist (col.transform.position))
            return true;
        return false;
    }

    private float dist (Vector3 col)
    {
        Vector2 dist = transform.position - col;
        return dist.sqrMagnitude;
    }

    private void OnDrawGizmos ()
    {
        Gizmos.DrawWireCube (transform.position, new Vector3 (radius, radius));
    }
}