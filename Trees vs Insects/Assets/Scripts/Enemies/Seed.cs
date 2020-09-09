using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    [SerializeField]
    private int seed = 0;
    private RandomNumberGenerator random;
    private void Start()
    {
        NewGenerator();
    }
    public void NewGenerator()
    {
        if (seed != 0)
            random = new RandomNumberGenerator(seed);
        else
            random = new RandomNumberGenerator();
    }
}

