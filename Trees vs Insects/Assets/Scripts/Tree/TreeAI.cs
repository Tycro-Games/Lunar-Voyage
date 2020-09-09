using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAI : MonoBehaviour
{
    private TreeRecon treeRecon;
    private ITreeShoot treeShoot;
    private BoxCollider target;
    private void Start()
    {
        treeShoot = GetComponent<ITreeShoot>();
        treeRecon = GetComponent<TreeRecon>();
    }
    private void Update()
    {
        if (target != null && treeRecon.CheckSorounding(target))
        {
            return;
        }
        BoxCollider colTarget = treeRecon.CheckSorounding();

        if (colTarget != null)
        {
            target = colTarget;
            StartCoroutine(treeShoot.Shoot(target.transform));
        }
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    private void OnDrawGizmos()
    {
        if (target != null)
            Gizmos.DrawLine(transform.position, target.transform.position);
    }
}
