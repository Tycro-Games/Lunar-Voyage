using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSeedContainer : MonoBehaviour
{
    [SerializeField]
    private TreeSeed treeSeed = null;
    private TreeSeedDisplay treeSeedDisplay = null;
    private TreeSeedSender treeSeedSender = null;
    private void Start()
    {
        treeSeedDisplay = GetComponent<TreeSeedDisplay>();
        treeSeedSender = GetComponentInParent<TreeSeedSender>();

        treeSeedDisplay.DisplaySprite(treeSeed.icon);
    }

    public void OnClick()
    {
        treeSeedSender.ChangeCurrentSeed(treeSeed);
    }
}
