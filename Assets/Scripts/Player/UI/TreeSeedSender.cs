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

        public void CancelCurrentSeed()
        {
            if (hasSeed)
            {
                OnResetSeed?.Invoke();

                hasSeed = false;

                seedDisplay.UpdateSprite(null);
                treePlacer.UpdateSprite(null);
            }
        }

        public void ChangeCurrentSeed(TreeSeed seed)
        {
            hasSeed = true;
            OnResetSeed?.Invoke();
            OnChangeSeed?.Invoke(seed);
            seedDisplay.UpdateSprite(seed.sprite, seed.TreeGameObject,seed.fruit);
            treePlacer.UpdateSprite(seed.TreeGameObject, seed.fruit);
        }

        public void ChangeCurrent(TreeSeed seed)
        {
            hasSeed = true;
            OnResetSeed?.Invoke();

            seedDisplay.ChangeSprite(seed.sprite);
            treePlacer.UpdateNonPlaceable(seed.TreeGameObject);
        }

        private void OnEnable()
        {
            TreePlacer.OnBuyCheck += CancelCurrentSeed;
        }

        private void OnDisable()
        {
            TreePlacer.OnBuyCheck -= CancelCurrentSeed;
        }

        private void Awake()
        {
            market = FindObjectOfType<Market>();

            treePlacer = FindObjectOfType<TreePlacer>();
            seedDisplay = FindObjectOfType<CurrentSeedDisplay>();
        }
    }
}