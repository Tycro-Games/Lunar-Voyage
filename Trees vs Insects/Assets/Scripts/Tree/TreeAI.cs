using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAI : MonoBehaviour
{
    private TreeRecon treeRecon;
    private ITreeShoot treeShoot;
    private Transform target;
    private void Start()
    {
        treeShoot = GetComponent<TreeShoot>();
        treeRecon = GetComponent<TreeRecon>();
    }
    private void Update()
    {
        if (target != null)
        {
            return;
        }

        Collider colTarget = treeRecon.CheckSorounding();
        if (colTarget != null)
        {
            target = colTarget.transform;
            StartCoroutine(treeShoot.Shoot(target));
        }
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    private void OnDrawGizmos()
    {
        if (target != null)
            Gizmos.DrawLine(transform.position, target.position);
    }
}
