using System;

namespace Bogadanul.Assets.Scripts.Tree
{
    public static class MarketIntro
    {
        private static int water = 0;

        public static event Action<int> OnEnergyChange;

        public static int WaterInst
        {
            get => water;
            set
            {
                water = value;
                OnEnergyChange (water);
            }
        }

        public static void Add (int d) => WaterInst += d;

        public static void Init (int statingWater)
        {
            WaterInst = statingWater;
        }

        public static void Substract (int d) => WaterInst -= d;
    }
}