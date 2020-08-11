﻿using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform target = null;

    private Pathfinding pathfinding;
    void Awake()
    {
        pathfinding = GetComponent<Pathfinding>();
    }
    void Start()
    {
        pathfinding.Init(target);
    }
    public void Spawn(GameObject enemyPrefab)
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
        Pathfinding enemyPath = enemy.GetComponent<Pathfinding>();
        enemyPath.Init(target);
    }
}
