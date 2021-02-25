using System;
using UnityEngine;
using UnityEngine.Events;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class MarketIntro : MonoBehaviour
    {
        private int water = 0;

        [SerializeField]
        private UnityEvent OnBuy;

        private bool onBuy = true;

        [SerializeField]
        private UnityEvent OnCollect;

        private bool onCollect = true;

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

        public void ChangeBuyEvents ()
        {
            onBuy = !onBuy;
        }

        public void ChangeOnCollect ()
        {
            onCollect = !onCollect;
        }

        public void Add (int d)
        {
            if (onCollect)
                OnCollect?.Invoke ();
            WaterInst += d;
        }

        public void Substract (int d)
        {
            if (onBuy)
                OnBuy?.Invoke ();
            WaterInst -= d;
        }
    }
}