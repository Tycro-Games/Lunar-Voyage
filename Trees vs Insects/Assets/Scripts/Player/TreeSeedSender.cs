using Bogadanul.Assets.Scripts.Tree;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Player
{
    public class TreeSeedSender : MonoBehaviour
    {
        [HideInInspector]
        public Market market = null;

        private bool hasSeed = false;
        private ICurrentSeedDisplay<Sprite> seedDisplay;
        private ICurrentSeedDisplay<GameObject> treePlacer;

        public void CancelCurrentSeed ()
        {
            if (hasSeed)
            {
                hasSeed = false;

                seedDisplay.UpdateSprite (null);
                treePlacer.UpdateSprite (null);
            }
        }

        public void ChangeCurrentSeed (TreeSeed seed)
        {
            hasSeed = true;

            seedDisplay.UpdateSprite (seed.sprite);
            treePlacer.UpdateSprite (seed.TreeGameObject);
        }

        private void Awake ()
        {
            market = FindObjectOfType<Market> ();

            treePlacer = FindObjectOfType<TreePlacer> ();
            seedDisplay = FindObjectOfType<CurrentSeedDisplay> ();
        }
    }
}