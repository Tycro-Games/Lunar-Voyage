using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TracePath : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;
    private List<Node> path = new List<Node> ();

    public List<Node> SetPath {
      

        set
        {
            path = value;
            StartPath ();
        }
    }

    public void StartPath ()
    {

        StopAllCoroutines ();
        StartCoroutine (FollowPath (path));
    }
    private void Update ()
    {
        if (Input.GetKeyDown (KeyCode.A))
        {
            StartPath ();
        }
    }
    IEnumerator FollowPath (List<Node> path)
    {

        int i = 0;
        while (i < path.Count)
        {


            yield return StartCoroutine (Move (path[i].worldPosition));
            i++;
        }
    }

    IEnumerator Move (Vector3 node)
    {
        while (transform.position != node)
        {

            transform.position = Vector3.MoveTowards (transform.position, node, speed * Time.deltaTime);

            Debug.DrawLine (transform.position, transform.position + Dir (node));
            yield return null;
        }
    }
    Vector3 Dir (Vector3 thingTolookAt)
    {
        Vector2 dir = (thingTolookAt - transform.position).normalized;
        return dir;
    }
    private void OnDrawGizmos ()
    {
        if (path != null)
        {
            foreach (Node n in path)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube (n.worldPosition, Vector3.one );
            }
        }
    }
}

