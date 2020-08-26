using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IProjectile
{
    [SerializeField]
    private float speed = 0;
    [SerializeField]
    private float distanceToHit = .25f;
    [SerializeField]
    private int damage = 1;
    private Transform target;
    private EnemyAI enemyAI;

    public void Init(Transform Target)
    {
        target = Target;
        enemyAI = target.GetComponent<EnemyAI>();
    }
    private void Update()
    {

        if (target == null)
        {
            DestroyProjectile();
            return;
        }
        MoveToTarget();
        CheckSpace();
    }
    void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
    }
    void CheckSpace()
    {
        if ((target.position - transform.position).sqrMagnitude < distanceToHit * distanceToHit)
        {
            enemyAI.TakeDamage(damage);
            DestroyProjectile();
        }

    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
