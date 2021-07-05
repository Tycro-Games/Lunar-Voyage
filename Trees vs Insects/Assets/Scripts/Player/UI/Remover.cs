using Bogadanul.Assets.Scripts.Player;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player.UI
{
    public class Remover : ContainerBase
    {
        public void OnClick()
        {
            if (Selected)
            {
                treeSeedSender.CancelCurrentSeed();
                Selected = false;
                return;
            }

            treeSeedSender.ChangeCurrent(treeSeed);
            Selected = true;
        }

        private void Start()
        {
            treeSeedSender = FindObjectOfType<TreeSeedSender>();
            treeSeedSender.OnResetSeed += Deselect;
            treeSeedDisplay = GetComponent<TreeSeedDisplay>();
            Displaying();
        }
    }
}