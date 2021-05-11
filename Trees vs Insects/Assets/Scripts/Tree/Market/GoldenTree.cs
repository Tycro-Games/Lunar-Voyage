using UnityEngine;
using UnityEngine.Events;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class GoldenTree : MarketGetter
    {
        [SerializeField]
        private int energyGain = 50;

        [SerializeField]
        private UnityEvent OnDestroy;

        public void AddEnergy()
        {
            market.Add(energyGain);
        }

        public void OnMouseDown()
        {
            AddEnergy();
            OnDestroy?.Invoke();
            Destroy(gameObject);
        }

        private void Awake()
        {
            GetMarket();
        }
    }
}