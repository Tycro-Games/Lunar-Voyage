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
        Market.OnEnergyChange += UpdateText;
    }
    void OnDisable()
    {
        Market.OnEnergyChange -= UpdateText;
    }

    void UpdateText(int value)
    {
        text.text = value.ToString();
    }
}
