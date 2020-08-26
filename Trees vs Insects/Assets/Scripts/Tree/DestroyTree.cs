using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTree : MonoBehaviour
{
    public void DestroyTheTree()
    {
        Destroy(gameObject);
        EnemyManager.CheckSpace();
    }
}
