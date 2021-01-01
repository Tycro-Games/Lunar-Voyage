using Bogadanul.Assets.Scripts.Tree;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Player
{
    public class Market : MonoBehaviour
    {
        private MarketIntro marketIntro;

        private int lastPrice = 0;

        [SerializeField]
        private int energyStart = 50;

        public void Add ()
        {
            marketIntro.WaterInst += lastPrice;
        }

        public bool CheckPrice (int price)
        {
            int energy = marketIntro.WaterInst;

            if (energy - price < 0)
            {
                return false;
            }
            else
            {
                lastPrice = price;
                return true;
            }
        }

        public void Substract ()
        {
            marketIntro.WaterInst -= lastPrice;
        }

        private void Awake ()
        {
            marketIntro = GetComponent<MarketIntro> ();
        }

        private void Start ()
        {
            marketIntro.Init (energyStart);
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