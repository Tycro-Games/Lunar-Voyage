using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeLifetime : MonoBehaviour
{
    private DestroyTree destroy;
    [SerializeField]
    private float lifetime = 0;
    private void Start()
    {
        destroy = GetComponent<DestroyTree>();
    }
    public void IsTooOld(float time)
    {
        lifetime -= time;
        if (lifetime <= 0)
        {
            destroy.DestroyTheTree();
        }

    }
}
