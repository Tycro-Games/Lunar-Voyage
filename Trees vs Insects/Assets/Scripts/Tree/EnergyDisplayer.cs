using TMPro;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class EnergyDisplayer : MonoBehaviour
    {
        private TextMeshProUGUI text;

        private void Awake ()
        {
            text = GetComponent<TextMeshProUGUI> ();
        }

        private void OnDisable ()
        {
            MarketIntro.OnEnergyChange -= UpdateText;
        }

        private void OnEnable ()
        {
            MarketIntro.OnEnergyChange += UpdateText;
        }

        private void UpdateText (int value)
        {
            text.text = value.ToString ();
        }
    }
}