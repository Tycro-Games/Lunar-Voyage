using UnityEngine;

public class RandomNumberGenerator
{
    private int seed;
    public int Seed { get => seed; set => seed = value; }


    public RandomNumberGenerator(int _seed)
    {
        Seed = _seed;
        Random.InitState(Seed);
    }
    public RandomNumberGenerator()
    {
        Seed = Random.Range(0, 10000);
        Random.InitState(Seed);
    }
}
