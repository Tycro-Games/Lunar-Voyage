﻿using Bogadanul.Assets.Scripts.Tree;
using UnityEngine;
using UnityEngine.UI;

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
        private Button button = null;
        private Market market = null;

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

        public void Onvalue (int current)
        {
            if (treeSeed.price > current)
                button.interactable = false;
            else if (cooldown.IsDone)
            {
                button.interactable = true;
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
            market.marketIntro.OnEnergyChange -= Onvalue;
        }

        private void Start ()
        {
            button = GetComponent<Button> ();
            market = FindObjectOfType<Market> ();
            market.marketIntro.OnEnergyChange += Onvalue;
            treeSeedDisplay = GetComponent<TreeSeedDisplay> ();
            treeSeedSender = GetComponentInParent<TreeSeedSender> ();
            cooldown = GetComponent<Cooldown> ();
            cooldown.Init (treeSeed.cooldown);
            Displaying ();
        }
    }
}