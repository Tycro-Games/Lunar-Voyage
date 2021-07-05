using System;
using System.Collections;
using Assets.Scripts.Tree.Interface;
using Bogadanul.Assets.Scripts.Enemies;
using Bogadanul.Assets.Scripts.Tree;
using Bogadanul.Assets.Scripts.Utility;
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

        [SerializeField]
        private GameObject DirtSnap = null;

        public bool UnWalkable()
        {
            if (currentTree.layer == layer)
                return true;
            return false;
        }

        private CursorController cursorController = null;

        public void Place(Vector3 input)
        {
            if (currentTree != null)
            {
                if (placeable)
                {
                    Node n = raycaster.NodeFromInput(input);
                    if (n == null)
                        return;

                    if (!canBe)
                        CheckNode(n);
                    else if (n.FruitPlaceable())
                    {
                        checkPlacer.ToSpawn(n, currentTree);
                        Placing();
                    }
                }
                else //this is the shovel
                {
                    Node n = raycaster.NodeFromInput(input);
                    if (n == null)
                        return;
                    GameObject ng = n.currentPlant;
                    if (ng != null && ng.CompareTag("Plant"))
                    {
                        //Here you can destroy the plant
                        Instantiate(DirtSnap, ng.transform.position, Quaternion.identity);
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

        public bool CustomChecks()
        {
            CustomChecks check = currentTree.GetComponent<CustomChecks>();
            if (check != null)
                return true;
            return false;
        }

        private void CheckNode(Node n)
        {
            CustomChecks check = currentTree.GetComponent<CustomChecks>();
            if (check != null)
            {
                if (n.TowerPlaceAble() && check.CustomCheck(n))
                {
                    if (checkPlacer.CheckToPlace(n, currentTree))
                        Placing();
                }
            }
            else
            {
                if (n.TowerPlaceAble() && checkPlacer.CheckToPlace(n, currentTree))
                {
                    Placing();
                }
            }
        }

        private void Placing()
        {
            currentTree = null;
            TreeSeedContainer.ActivateCoolDown();
            OnBuyCheck?.Invoke();
        }

        private void OnDisable()
        {
            cursorController.OnMovement -= Place;
        }

        private void Start()
        {
            cursorController = FindObjectOfType<CursorController>();
            cursorController.OnMovement += Place;
            seedSender = FindObjectOfType<TreeSeedSender>();
            layer = (int)Mathf.Log(BlockLayer.value, 2);
            checkPlacer = GetComponent<CheckPlacerPath>();
            raycaster = GetComponent<NodeFinder>();
        }
    }
}