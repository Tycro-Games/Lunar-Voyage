using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParentChecker : MonoBehaviour
{

    public void CheckChildren()
    {
        if (transform.childCount == 1)//this is fucked up but if this is called that means the enemy will die so it s fine
            Destroy(gameObject);

    }
}
