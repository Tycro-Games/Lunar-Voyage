using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class AnimationStart : MonoBehaviour
    {
        private void Start()
        {
            GetComponentInParent<AnimateText>().GetNewText(GetComponent<TextMeshProUGUI>());
        }
    }
}