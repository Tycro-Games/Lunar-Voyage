using UnityEngine;
using TMPro;
public class EnergyDisplayer : MonoBehaviour
{
    private TextMeshProUGUI text;
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();

    }
    void OnEnable()
    {
        MarketIntro.OnEnergyChange += UpdateText;
        UpdateText(MarketIntro.WaterInst);
    }
    void OnDisable()
    {
        MarketIntro.OnEnergyChange -= UpdateText;
    }

    void UpdateText(int value)
    {
        text.text = value.ToString();
    }
}
