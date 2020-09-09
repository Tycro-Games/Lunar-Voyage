using System;
using UnityEngine;

public static class MarketIntro
{

    static int water = 0;
    public static event Action<int> OnEnergyChange;
    public static int WaterInst
    {
        get => water;
        set
        {
            water = value;
            OnEnergyChange(water);
        }
    }
    public static void Init(int statingWater)
    {
        water = statingWater;
    }
    public static void Add(int d) => WaterInst += d;
    public static void Substract(int d) => WaterInst -= d;
}
