using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Bogadanul.Assets.Scripts.Player
{
    public class TreeSeedDisplay : MonoBehaviour
    {
        private Image image;
        private TextMeshProUGUI text;
        private Color normal;

        public void DisplayPrice(int price)
        {
            if (price > 0)
                text.text = price.ToString();
            else
                text.text = " ";
        }

        public void DisplaySprite(Sprite sprite)
        {
            image.sprite = sprite;
        }

        public void ChangeColor(Color color)
        {
            image.color = color;
        }

        public void ResetColor()
        {
            image.color = normal;
        }

        private void Awake()
        {
            image = GetComponent<Image>();
            normal = image.color;
            text = GetComponentInChildren<TextMeshProUGUI>();
        }
    }
}