using Assets.Scripts.Tree.Interface;
using Assets.Scripts.Tree.TreeModules;
using Bogadanul.Assets.Scripts.Enemies;
using Bogadanul.Assets.Scripts.Tree;
using Bogadanul.Assets.Scripts.Utility;
using System;
using System.Collections;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Player
{
    public class TreePlacer : MonoBehaviour
    {
        private static int layer;
        private CheckPlacerPath checkPlacer;

        [SerializeField]
        private  GameObject currentTree = null;

        private NodeFinder raycaster;

        [SerializeField]
        private LayerMask BlockLayer = 0;

        private bool canBe = false;

        public static event Action OnBuyCheck;

        private bool placeable = false;
        private TreeSeedSender seedSender = null;

        [SerializeField]
        private GameObject EffectOnRemove = null;

        [SerializeField]
        private GameObject EffectOnPlace = null;

        private DisplayFreeCells freeCells = null;

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
                    else if (!freeCells.OnlyOnePathTiles.Contains(n) && n.FruitPlaceable())
                    {
                        CheckPlacerPath.ToSpawn(n, currentTree);
                        Instantiate(EffectOnPlace, n.worldPosition, Quaternion.identity);

                        Placing(n);
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
                        Instantiate(EffectOnRemove, ng.transform.position, Quaternion.identity);
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
            PotCheck check = currentTree.GetComponent<PotCheck>();
            if (check != null)//with pot
            {
                if (check.canBePlaced(n) && !freeCells.OnlyOnePathTiles.Contains(n))
                {
                    if (CheckPlacerPath.CheckToPlace(n, currentTree))
                    {
                        Placing(n);
                    }
                }
            }
            else//no pot
            {
                if (n.TowerPlaceAble() && !freeCells.OnlyOnePathTiles.Contains(n))
                {
                    if (CheckPlacerPath.CheckToPlace(n, currentTree))
                        Placing(n);
                }
            }
        }

        private void Placing(Node n)
        {
            Instantiate(EffectOnPlace, n.worldPosition, Quaternion.identity);
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
            freeCells = FindObjectOfType<DisplayFreeCells>();
        }
    }
}