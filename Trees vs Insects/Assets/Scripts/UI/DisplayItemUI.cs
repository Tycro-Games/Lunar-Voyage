using Assets.Scripts.UI;
using Bogadanul.Assets.Scripts.Tree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Bogadanul.Assets
{
    public class DisplayItemUI : MonoBehaviour
    {
        private LevelEndSeedDisplayable displayNewItem = null;
        private Image image = null;
        private TextMeshProUGUI text = null;

        private void Start()
        {
            image = GetComponentInChildren<Image>();
            text = GetComponentInChildren<TextMeshProUGUI>();
            displayNewItem = FindObjectOfType<GetterSeedDisplayer>().LevelEndSeedDisplayable;
            image.sprite = displayNewItem.icon;
            text.text = displayNewItem.description;
        }
    }
}