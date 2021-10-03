﻿using Assets.Scripts.Tree.Interface;
using Bogadanul.Assets.Scripts.Utility;
using System;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Player
{
    public class CurrentSeedDisplay : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer cursor = null;

        [SerializeField]
        private Sprite cursorSprite = null;

        private NodeFinder node;

        private SpriteRenderer spriteRen = null;

        private DisplayRange displayRange = null;
        private DisplayFreeCells freeCells = null;

        private bool canBePlaced = false;

        private CursorController cursorController = null;
        private Node lastnode = null;

        public event Action<bool> OnRangeDisplay = null;

        public event Action<bool> OnPlace = null;

        public bool IsFruit { get => canBePlaced; set => canBePlaced = value; }
        private bool placeable = false;

        public bool Placeable
        {
            get => placeable;
            set
            {
                placeable = value;
                OnPlace?.Invoke(!IsFruit);
            }
        }

        private TreePlacer treePlacer;
        private CustomChecks check = null;

        public void ResetSprite()
        {
            OnRangeDisplay?.Invoke(false);

            spriteRen.sprite = null;
            cursor.sprite = cursorSprite;
        }

        public void UpdateSprite(Sprite seed, bool canBeP = false)
        {
            if (seed)
            {
                IsFruit = canBeP;
                spriteRen.sprite = seed;

                transform.position = cursor.transform.position;

                cursor.sprite = spriteRen.sprite;
                Placeable = true;
            }
            else
            {
                Placeable = false;
                ResetSprite();
            }
        }

        public void ChangeSprite(Sprite seed)
        {
            if (seed)
            {
                spriteRen.enabled = false;
                spriteRen.sprite = seed;
                transform.position = cursor.transform.position;

                cursor.sprite = spriteRen.sprite;
                Placeable = false;
            }
        }

        private void Update()
        {
            Node n = node.NodeFromInput(cursorController.MousePosition());

            if (Placeable)
            {
                CheckPlaceables(n);

                Debug.Log("check");
            }
            else if (spriteRen.sprite != null)
            {
                CheckForPlants(n);
            }
        }

        private void CheckForPlants(Node n)
        {
            if (n != null && n != lastnode)
            {
                lastnode = n;
                transform.position = n.worldPosition;
            }
            if (n == null)
                return;
            GameObject ng = n.currentPlant;
            if (ng != null && ng.CompareTag("Plant"))
                spriteRen.enabled = true;
            else
                spriteRen.enabled = false;
        }

        private void CheckPlaceables(Node n)
        {
            if (spriteRen.sprite != null)
            {
                GameObject checkObj = null;
                if (n != null && n != lastnode)
                {
                    checkObj = n.currentPlant;
                    if (treePlacer.CustomChecks() && checkObj != null)
                        if (checkObj.TryGetComponent(out check))
                            check = n.currentPlant.GetComponent<CustomChecks>();
                    lastnode = n;
                    transform.position = n.worldPosition;
                }

                OnRangeDisplay?.Invoke(true);
                displayRange.DisplayTheRange(n);

                if (!IsFruit)
                {
                    if (check == null)
                        spriteRen.enabled = n?.TowerPlaceAble() == true && !freeCells.OnlyOnePathTiles.Contains(n);
                    else
                    {
                        spriteRen.enabled = n?.TowerPlaceAble() == true && check.CustomCheck(n) && !freeCells.OnlyOnePathTiles.Contains(n);
                    }
                }
                else
                    spriteRen.enabled = n?.FruitPlaceable() == true ;
            }
        }

        private void Awake()
        {
            spriteRen = GetComponent<SpriteRenderer>();
            displayRange = GetComponent<DisplayRange>();
            freeCells = FindObjectOfType<DisplayFreeCells>();
        }

        private void Start()
        {
            cursorController = FindObjectOfType<CursorController>();
            node = GetComponent<NodeFinder>();
            treePlacer = FindObjectOfType<TreePlacer>();
        }
    }
}