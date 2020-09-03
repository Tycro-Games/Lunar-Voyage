using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour
{
    public int energy = 10;

    public int EnergyInst
    {
        get => energy;
        set
        {
            energy = value;
            OnEnergyChange(energy);
        }
    }

    public static event Action<int> OnEnergyChange;
    void Start()
    {
        OnEnergyChange(energy);//display some text
    }
    public void CheckPrice(int price)
    {
        int energy = EnergyInst;

        if (energy - price <= 0)
            return;
        else
        {
            Substract(price);
        }
    }
    public void Substract(int d)
    {
        EnergyInst -= d;
    }
    public void Add(int d)
    {
        EnergyInst += d;
    }
}