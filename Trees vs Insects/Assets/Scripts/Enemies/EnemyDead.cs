using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDead : MonoBehaviour
{
    EnemyHealth enemyHealth;
    [SerializeField]
    private UnityEvent OnDie = null;
    private void Awake()
    {
        enemyHealth = GetComponentInChildren<EnemyHealth>();
    }
    private void OnEnable()
    {
        EnemyList.List.Add(gameObject);

        enemyHealth.OnDead += DestroyEnemy;
    }
    private void OnDisable()
    {
        enemyHealth.OnDead -= DestroyEnemy;
    }
    public void DestroyEnemy()
    {
        EnemyList.List.Remove(gameObject);
        EnemyList.CheckEnemies();

        Destroy(gameObject);

        OnDie?.Invoke();
    }
}
