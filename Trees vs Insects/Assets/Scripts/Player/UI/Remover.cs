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
            Selected = true;
            treeSeedSender.ChangeCurrent(treeSeed);
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