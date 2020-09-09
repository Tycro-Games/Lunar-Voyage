
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TreeSeedDisplay : MonoBehaviour
{
    private Image image;
    private TextMeshProUGUI text;
    private void Awake()
    {
        image = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void DisplaySprite(Sprite sprite)
    {
        image.sprite = sprite;
    }
    public void DisplayPrice(int price)
    {
        text.text = price.ToString();
    }
}
