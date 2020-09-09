using System;
using UnityEngine;

public class TreeSeedSender : MonoBehaviour
{
    private ICurrentSeedDisplay<GameObject> treePlacer;
    private ICurrentSeedDisplay<Sprite> seedDisplay;
    [HideInInspector]
    public Market market = null;
    private bool hasSeed = false;

    private void Awake()
    {
        market = FindObjectOfType<Market>();

        treePlacer = FindObjectOfType<TreePlacer>();
        seedDisplay = FindObjectOfType<CurrentSeedDisplay>();
    }
    public void ChangeCurrentSeed(TreeSeed seed)
    {
        hasSeed = true;

        seedDisplay.UpdateSprite(seed.sprite);
        treePlacer.UpdateSprite(seed.TreeGameObject);
    }
    public void CancelCurrentSeed()
    {
        if (hasSeed)
        {
            hasSeed = false;

            seedDisplay.UpdateSprite(null);
            treePlacer.UpdateSprite(null);
        }
    }

}
