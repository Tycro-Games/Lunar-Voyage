using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyListChecker : MonoBehaviour
{
    public event Action OnNoEnemies;

    private void OnEnable()
    {
        EnemyList.OnNoEnemies += CheckList;
    }
    private void OnDisable()
    {
        EnemyList.OnNoEnemies -= CheckList;
    }
    private void Start()
    {
        CheckList();
    }
    private void CheckList()
    {
        OnNoEnemies?.Invoke();
    }
}
