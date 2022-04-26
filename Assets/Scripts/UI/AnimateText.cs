using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class AnimateText : MonoBehaviour
    {
        [SerializeField]
        [TextArea]
        private string[] itemInfo;

        [SerializeField]
        private float textSpeed = 0.01f;

        private TextMeshProUGUI itemInfoText;
        private int currentDisplayingText = 0;

        public void GetNewText(TextMeshProUGUI text)
        {
            itemInfoText = text;
            itemInfo[currentDisplayingText] = text.text;
            text.text = "";
            ActivateText();
        }

        public void ActivateText()
        {
            StartCoroutine(AnimatingText());
        }

        private IEnumerator AnimatingText()
        {
            for (int i = 0; i < itemInfo[currentDisplayingText].Length + 1; i++)
            {
                itemInfoText.text = itemInfo[currentDisplayingText].Substring(0, i);
                yield return new WaitForSeconds(textSpeed);
            }
        }
    }
}