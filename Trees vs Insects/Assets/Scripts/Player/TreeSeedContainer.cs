using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSeedContainer : MonoBehaviour
{
    [SerializeField]
    private TreeSeed treeSeed = null;
    private TreeSeedSender treeSeedSender = null;

    private TreeSeedDisplay treeSeedDisplay = null;
    private void Start()
    {
        treeSeedDisplay = GetComponent<TreeSeedDisplay>();
        treeSeedSender = GetComponentInParent<TreeSeedSender>();

        Displaying();
    }
    void Displaying()
    {
        treeSeedDisplay.DisplaySprite(treeSeed.icon);
        treeSeedDisplay.DisplayPrice(treeSeed.price);
    }

    public void OnClick()
    {
        if (treeSeedSender.market.CheckPrice(treeSeed.price))
            treeSeedSender.ChangeCurrentSeed(treeSeed);
    }
}
