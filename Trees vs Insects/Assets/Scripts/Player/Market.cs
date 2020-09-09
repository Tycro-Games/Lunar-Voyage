using System;
using UnityEngine;

public class Market : MonoBehaviour
{
    [SerializeField]
    private int startWater = 0;
    private int lastPrice = 0;
    private void Awake()
    {
        MarketIntro.Init(startWater);
    }
    private void OnEnable()
    {
        TreePlacer.OnBuyCheck += Substract;
    }
    private void OnDisable()
    {
        TreePlacer.OnBuyCheck -= Substract;
    }
    public bool CheckPrice(int price)
    {
        int energy = MarketIntro.WaterInst;

        if (energy - price < 0)
            return false;
        else
        {
            lastPrice = price;
            return true;
        }
    }
    public void Substract()
    {
        MarketIntro.WaterInst -= lastPrice;
    }

    public void Add()
    {
        MarketIntro.WaterInst += lastPrice;
    }

}