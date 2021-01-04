using Bogadanul.Assets.Scripts.Tree;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Player
{
    public class TreeSeedContainer : MonoBehaviour
    {
        public static TreeSeedContainer treeSeedContainer;

        [SerializeField]
        private TreeSeed treeSeed = null;

        private TreeSeedDisplay treeSeedDisplay = null;
        private TreeSeedSender treeSeedSender = null;
        private Cooldown cooldown;
        private bool selected = false;

        public void OnClick ()
        {
            if (selected)
            {
                treeSeedSender.CancelCurrentSeed ();
                selected = false;
                return;
            }
            if (treeSeedSender.market.CheckPrice (treeSeed.price))
            {
                treeSeedSender.ChangeCurrentSeed (treeSeed);
                selected = true;
                treeSeedContainer = this;
            }
        }

        public void ActivateDown ()
        {
            if (selected)
            {
                cooldown.ResetT ();
                selected = false;
            }
        }

        private void Displaying ()
        {
            treeSeedDisplay.DisplaySprite (treeSeed.icon);
            treeSeedDisplay.DisplayPrice (treeSeed.price);
        }

        private void ActivateCoolDown ()
        {
            treeSeedContainer.ActivateDown ();
        }

        private void OnEnable ()
        {
            TreePlacer.OnBuyCheck += ActivateCoolDown;
        }

        private void OnDisable ()
        {
            TreePlacer.OnBuyCheck -= ActivateCoolDown;
        }

        private void Start ()
        {
            treeSeedDisplay = GetComponent<TreeSeedDisplay> ();
            treeSeedSender = GetComponentInParent<TreeSeedSender> ();
            cooldown = GetComponent<Cooldown> ();
            cooldown.Init (treeSeed.cooldown);
            Displaying ();
        }
    }
}