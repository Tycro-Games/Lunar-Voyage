using Bogadanul.Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.Timeline;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class GoldenTree : MarketGetter
    {
        [SerializeField]
        private int energyGain = 50;

        public void AddEnergy ()
        {
            market.Add (energyGain);
        }

        private void Awake ()
        {
            GetMarket ();
        }
    }
}