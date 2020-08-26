using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracePathCheck : MonoBehaviour
{

    protected List<Node> path = new List<Node>();
    public virtual List<Node> SetPath
    {
        get
        {
            return path;
        }
        set
        {
            path = value;
        }
    }
    private void OnDrawGizmos()
    {
        if (path != null)
        {
            foreach (Node n in path)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(n.worldPosition, Vector3.one);
            }
        }
    }
}
