using Bogadanul.Assets.Scripts.Tree;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Player
{
    public class Market : MonoBehaviour
    {
        private int lastPrice = 0;

        [SerializeField]
        private int startWater = 0;

        public void Add ()
        {
            MarketIntro.WaterInst += lastPrice;
        }

        public bool CheckPrice (int price)
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

        public void Substract ()
        {
            MarketIntro.WaterInst -= lastPrice;
        }

        private void Awake ()
        {
            MarketIntro.Init (startWater);
        }

        private void OnDisable ()
        {
            TreePlacer.OnBuyCheck -= Substract;
        }

        private void OnEnable ()
        {
            TreePlacer.OnBuyCheck += Substract;
        }
    }
}