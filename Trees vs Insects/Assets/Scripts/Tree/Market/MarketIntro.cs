using System;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class MarketIntro : MonoBehaviour
    {
        private int water = 0;

        public event Action<int> OnEnergyChange;

        public int WaterInst
        {
            get => water;
            set
            {
                water = value;
                OnEnergyChange?.Invoke (water);
            }
        }

        public void Init (int statingWater)
        {
            WaterInst = statingWater;
        }

        public void Add (int d) => WaterInst += d;

        public void Substract (int d) => WaterInst -= d;
    }
}