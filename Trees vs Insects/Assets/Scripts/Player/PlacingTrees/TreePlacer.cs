using System;
using Bogadanul.Assets.Scripts.Tree;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Player
{
    public class TreePlacer : MonoBehaviour
    {
        private static int layer;
        private CheckPlacerPath checkPlacer;

        [SerializeField]
        private GameObject currentTree = null;

        private NodeFinder raycaster;

        [SerializeField]
        private LayerMask BlockLayer = 0;

        private bool canBe = false;

        public static event Action OnBuyCheck;

        public bool UnWalkable ()
        {
            if (currentTree.layer == layer)
                return true;
            return false;
        }

        public void Place ()
        {
            if (currentTree != null)
            {
                Node n = raycaster.NodeFromInput (Input.mousePosition);
                if (n == null)
                    return;
                if (!canBe)
                    CheckNode (n);
                else if (n.FruitPlaceable ())
                {
                    checkPlacer.ToSpawn (n, currentTree);
                    Placing ();
                }
            }
        }

        public void Reset ()
        {
            currentTree = null;
        }

        public void UpdateSprite (GameObject seed, bool canBeAny = false)
        {
            currentTree = seed;
            canBe = canBeAny;
        }

        private void CheckNode (Node n)
        {
            if (n.TowerPlaceAble () && checkPlacer.CheckToPlace (n, currentTree))
            {
                Placing ();
            }
        }

        private void Placing ()
        {
            currentTree = null;
            TreeSeedContainer.ActivateCoolDown ();
            OnBuyCheck?.Invoke ();
        }

        private void Start ()
        {
            layer = (int)Mathf.Log (BlockLayer.value, 2);
            checkPlacer = GetComponent<CheckPlacerPath> ();
            raycaster = GetComponent<NodeFinder> ();
        }
    }
}