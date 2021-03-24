using Bogadanul.Assets.Scripts.Tree;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Bogadanul.Assets.Scripts.Player
{
    public class TreeSeedContainer : ContainerBase
    {
        public static TreeSeedContainer treeSeedContainer;
        private Cooldown cooldown;

        public static void ActivateCoolDown()
        {
            treeSeedContainer.ActivateDown();
        }

        private void OnDisable()
        {
            treeSeedSender.OnResetSeed -= Deselect;
        }

        public void OnClick()
        {
            if (Selected)
            {
                treeSeedSender.CancelCurrentSeed();
                Selected = false;
                return;
            }
            if (treeSeedSender.market.CheckPrice(treeSeed.price))
            {
                treeSeedSender.ChangeCurrentSeed(treeSeed);

                Selected = true;
                treeSeedContainer = this;
            }
        }

        public void ActivateDown()
        {
            if (Selected)
            {
                cooldown.ResetT();
                Selected = false;
            }
        }

        private void Awake()
        {
            cooldown = GetComponent<Cooldown>();
            cooldown.Init(treeSeed.cooldown);
        }

        private void Start()
        {
            treeSeedDisplay = GetComponent<TreeSeedDisplay>();
            treeSeedSender = GetComponentInParent<TreeSeedSender>();
            treeSeedSender.OnResetSeed += Deselect;

            Displaying();
        }
    }
}