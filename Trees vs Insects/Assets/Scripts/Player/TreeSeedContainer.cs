using Bogadanul.Assets.Scripts.Tree;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Player
{
    public class TreeSeedContainer : MonoBehaviour
    {
        [SerializeField]
        private TreeSeed treeSeed = null;

        private TreeSeedDisplay treeSeedDisplay = null;
        private TreeSeedSender treeSeedSender = null;

        public void OnClick ()
        {
            if (treeSeedSender.market.CheckPrice (treeSeed.price))
                treeSeedSender.ChangeCurrentSeed (treeSeed);
        }

        private void Displaying ()
        {
            treeSeedDisplay.DisplaySprite (treeSeed.icon);
            treeSeedDisplay.DisplayPrice (treeSeed.price);
        }

        private void Start ()
        {
            treeSeedDisplay = GetComponent<TreeSeedDisplay> ();
            treeSeedSender = GetComponentInParent<TreeSeedSender> ();

            Displaying ();
        }
    }
}