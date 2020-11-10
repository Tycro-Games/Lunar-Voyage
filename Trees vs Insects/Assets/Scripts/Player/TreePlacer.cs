using Bogadanul.Assets.Scripts.Tree;
using System;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Player
{
    public class TreePlacer : MonoBehaviour, ICurrentSeedDisplay<GameObject>
    {
        private CheckPlacerPath checkPlacer;

        [SerializeField]
        private GameObject currentTree = null;

        private NodeFinder raycaster;

        public static event Action OnBuyCheck;

        public void Place ()
        {
            if (currentTree != null)
            {
                Node n = raycaster.NodeFromPoint (Input.mousePosition);
                if (n?.Placeable () == true && checkPlacer.CheckToPlace (n, currentTree))
                {
                    currentTree = null;
                    OnBuyCheck?.Invoke ();
                }
            }
        }

        public void UpdateSprite (GameObject seed)
        {
            currentTree = seed;
        }

        private void Start ()
        {
            checkPlacer = GetComponent<CheckPlacerPath> ();
            raycaster = GetComponent<NodeFinder> ();
        }
    }
}