using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeSeedDisplay : MonoBehaviour
{
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void DisplaySprite(Sprite sprite)
    {
        image.sprite = sprite;
    }
}
