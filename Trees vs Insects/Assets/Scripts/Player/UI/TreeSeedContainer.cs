using Bogadanul.Assets.Scripts.Tree;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Bogadanul.Assets.Scripts.Player
{
    public class TreeSeedContainer : MonoBehaviour
    {
        public static TreeSeedContainer treeSeedContainer;

        [SerializeField]
        public TreeSeed treeSeed = null;

        [SerializeField]
        private Color selectedColor;

        private Color normal;
        private TreeSeedDisplay treeSeedDisplay = null;
        private TreeSeedSender treeSeedSender = null;
        private Cooldown cooldown;
        private bool selected = false;
        private Button button = null;
        private Market market = null;

        public bool Selected
        {
            get => selected;
            set
            {
                selected = value;
                ChangeColor ();
            }
        }

        public static void ActivateCoolDown ()
        {
            treeSeedContainer.ActivateDown ();
        }

        public void OnClick ()
        {
            if (Selected)
            {
                treeSeedSender.CancelCurrentSeed ();
                Selected = false;
                return;
            }
            if (treeSeedSender.market.CheckPrice (treeSeed.price))
            {
                treeSeedSender.ChangeCurrentSeed (treeSeed);

                Selected = true;
                treeSeedContainer = this;
            }
        }

        public void ActivateDown ()
        {
            if (Selected)
            {
                cooldown.ResetT ();
                Selected = false;
            }
        }

        public void Deselect ()
        {
            Selected = false;
        }

        private void ChangeColor ()
        {
            if (selected)
            {
                treeSeedDisplay.ChangeColor (selectedColor);
            }
            else
                treeSeedDisplay.ResetColor ();
        }

        private void Displaying ()
        {
            treeSeedDisplay.DisplaySprite (treeSeed.icon);
            treeSeedDisplay.DisplayPrice (treeSeed.price);
        }

        private void OnDisable ()
        {
            treeSeedSender.OnResetSeed -= Deselect;
        }

        private void Awake ()
        {
            cooldown = GetComponent<Cooldown> ();
            cooldown.Init (treeSeed.cooldown);
        }

        private void Start ()
        {
            button = GetComponent<Button> ();
            market = FindObjectOfType<Market> ();

            treeSeedDisplay = GetComponent<TreeSeedDisplay> ();
            treeSeedSender = GetComponentInParent<TreeSeedSender> ();
            treeSeedSender.OnResetSeed += Deselect;

            Displaying ();
        }
    }
}