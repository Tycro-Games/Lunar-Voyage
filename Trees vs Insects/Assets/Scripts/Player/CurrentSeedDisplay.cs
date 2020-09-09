using UnityEngine;

public class CurrentSeedDisplay : MonoBehaviour, ICurrentSeedDisplay<Sprite>
{
    private SpriteRenderer spriteRen = null;
    private void Awake()
    {
        spriteRen = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        TreePlacer.OnBuyCheck += ResetSprite;
    }
    private void OnDisable()
    {
        TreePlacer.OnBuyCheck -= ResetSprite;
    }

    public void UpdateSprite(Sprite seed)
    {
        spriteRen.sprite = seed;
    }
    public void ResetSprite()
    {
        spriteRen.sprite = null;
    }
}
