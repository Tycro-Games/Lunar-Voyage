using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class TreeSeedDisplay : MonoBehaviour
    {
        private Image image;
        private TextMeshProUGUI text;

        public void DisplayPrice (int price)
        {
            text.text = price.ToString ();
        }

        public void DisplaySprite (Sprite sprite)
        {
            image.sprite = sprite;
        }

        private void Awake ()
        {
            image = GetComponent<Image> ();
            text = GetComponentInChildren<TextMeshProUGUI> ();
        }
    }
}