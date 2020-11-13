using TMPro;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class EnergyDisplayer : MarketGetter
    {
        private TextMeshProUGUI text;

        private void Awake ()
        {
            GetMarket ();
            text = GetComponent<TextMeshProUGUI> ();

            market.OnEnergyChange += UpdateText;
        }

        private void OnDisable ()
        {
            market.OnEnergyChange -= UpdateText;
        }

        private void UpdateText (int value)
        {
            text.text = value.ToString ();
        }
    }
}