using Bogadanul.Assets.Scripts.Tree;
using System;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Player
{
    public class TreeSeedSender : MonoBehaviour
    {
        [HideInInspector]
        public Market market = null;

        private CurrentSeedDisplay seedDisplay;

        private TreePlacer treePlacer;
        private bool hasSeed = false;

        public event Action<TreeSeed> OnChangeSeed = null;

        public event Action OnResetSeed = null;

        public void CancelCurrentSeed ()
        {
            if (hasSeed)
            {
                OnResetSeed?.Invoke ();
                hasSeed = false;

                seedDisplay.UpdateSprite (null);
                treePlacer.UpdateSprite (null);
            }
        }

        public void ChangeCurrentSeed (TreeSeed seed)
        {
            hasSeed = true;
            OnResetSeed?.Invoke ();
            OnChangeSeed?.Invoke (seed);
            seedDisplay.UpdateSprite (seed.sprite, seed.canBePlacedAnywhere);
            treePlacer.UpdateSprite (seed.TreeGameObject, seed.canBePlacedAnywhere);
        }

        private void OnEnable ()
        {
            TreePlacer.OnBuyCheck += CancelCurrentSeed;
        }

        private void OnDisable ()
        {
            TreePlacer.OnBuyCheck -= CancelCurrentSeed;
        }

        private void Awake ()
        {
            market = FindObjectOfType<Market> ();

            treePlacer = FindObjectOfType<TreePlacer> ();
            seedDisplay = FindObjectOfType<CurrentSeedDisplay> ();
        }
    }
}