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
        private Cooldown cooldown;
        private bool selected = false;

        public void OnClick ()
        {
            if (treeSeedSender.market.CheckPrice (treeSeed.price))
            {
                treeSeedSender.ChangeCurrentSeed (treeSeed);
                selected = true;
            }
        }

        private void Displaying ()
        {
            treeSeedDisplay.DisplaySprite (treeSeed.icon);
            treeSeedDisplay.DisplayPrice (treeSeed.price);
        }

        private void ActivateCoolDown ()
        {
            if (selected)
            {
                cooldown.ResetT ();
                selected = false;
            }
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