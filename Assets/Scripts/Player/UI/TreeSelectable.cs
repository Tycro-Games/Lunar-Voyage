using Bogadanul.Assets.Scripts.Tree;
using System.Collections;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Player
{
    public class TreeSelectable : MonoBehaviour
    {
        private TreeSeedDisplay seedDisplay = null;

        [SerializeField]
        private TreeSeed treeSeed = null;

        private void Start()
        {
            seedDisplay = GetComponent<TreeSeedDisplay>();
            Display();
        }

        private void Display()
        {
            seedDisplay.DisplayPrice(treeSeed.price);
            seedDisplay.DisplaySprite(treeSeed.icon);
        }
    }
}