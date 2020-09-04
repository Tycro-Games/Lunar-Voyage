using UnityEngine;

public class TreeSeedSender : MonoBehaviour
{
    private ICurrentSeedDisplay<GameObject> treePlacer;
    private ICurrentSeedDisplay<Sprite> seedDisplay;
    private void Awake()
    {
        treePlacer = FindObjectOfType<TreePlacer>();
        seedDisplay = FindObjectOfType<CurrentSeedDisplay>();
    }
    public void ChangeCurrentSeed(TreeSeed seed)
    {
        seedDisplay.UpdateSprite(seed.sprite);
        treePlacer.UpdateSprite(seed.TreeGameObject);
    }

}
