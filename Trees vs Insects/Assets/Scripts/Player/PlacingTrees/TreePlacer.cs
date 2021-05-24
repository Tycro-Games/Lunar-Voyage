using System;
using System.Collections;
using Bogadanul.Assets.Scripts.Enemies;
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

        private bool placeable = false;
        private TreeSeedSender seedSender = null;

        public bool UnWalkable()
        {
            if (currentTree.layer == layer)
                return true;
            return false;
        }

        public void Place()
        {
            if (currentTree != null)
            {
                if (placeable)
                {
                    Node n = raycaster.NodeFromInput(Input.mousePosition);
                    if (n == null)
                        return;

                    if (!canBe)
                        CheckNode(n);
                    else if (n.FruitPlaceable())
                    {
                        checkPlacer.CheckToPlace(n, currentTree);
                        Placing();
                    }
                }
                else
                {
                    Node n = raycaster.NodeFromInput(Input.mousePosition);
                    if (n == null)
                        return;
                    GameObject ng = n.currentPlant;
                    if (ng != null && ng.CompareTag("Plant"))
                    {
                        //Here you can destroy the plant;
                        ng.GetComponent<DestroyTree>().DestroyTheTree();
                        StartCoroutine(Counter());
                        seedSender.CancelCurrentSeed();
                        Reset();
                    }
                }
            }
        }

        public void Reset()
        {
            currentTree = null;
        }

        public static IEnumerator Counter()
        {
            yield return null;
            EnemyManager.SetSpace();
        }

        public void UpdateSprite(GameObject seed, bool canBeAny = false)
        {
            placeable = true;
            currentTree = seed;
            canBe = canBeAny;
        }

        public void UpdateNonPlaceable(GameObject seed)
        {
            placeable = false;
            currentTree = seed;
        }

        private void CheckNode(Node n)
        {
            if (n.TowerPlaceAble() && checkPlacer.CheckToPlace(n, currentTree))
            {
                Placing();
            }
        }

        private void Placing()
        {
            currentTree = null;
            TreeSeedContainer.ActivateCoolDown();
            OnBuyCheck?.Invoke();
        }

        private void Start()
        {
            seedSender = FindObjectOfType<TreeSeedSender>();
            layer = (int)Mathf.Log(BlockLayer.value, 2);
            checkPlacer = GetComponent<CheckPlacerPath>();
            raycaster = GetComponent<NodeFinder>();
        }
    }
}