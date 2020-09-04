using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSeedDisplay : MonoBehaviour, ICurrentSeedDisplay<Sprite>
{
    private SpriteRenderer spriteRen = null;
    private void Awake()
    {
        spriteRen = GetComponent<SpriteRenderer>();
    }
    public void UpdateSprite(Sprite seed)
    {
        spriteRen.sprite = seed;
    }
}
