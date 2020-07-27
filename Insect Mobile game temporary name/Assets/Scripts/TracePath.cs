using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracePath : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;
    private List<Node> path = new List<Node> ();
    public void GetPath ()
    {
        path = Grid.currentGrid.path; 
    }
    public void StartPath ()
    {
        StopAllCoroutines ();
        StartCoroutine (FollowPath (path));
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
}
