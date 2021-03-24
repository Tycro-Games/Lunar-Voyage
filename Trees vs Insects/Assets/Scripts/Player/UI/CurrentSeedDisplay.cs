﻿using Bogadanul.Assets.Scripts.Enemies;
using Bogadanul.Assets.Scripts.Tree;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

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

        private bool canBePlaced = false;

        private Vector2 mouse;

        private Node lastnode = null;

        public event Action<bool> OnRangeDisplay = null;

        public bool IsFruit { get => canBePlaced; set => canBePlaced = value; }

        public void MoveSprite(InputAction.CallbackContext ctx)
        {
            mouse = ctx.ReadValue<Vector2>();
        }

        public void ResetSprite()
        {
            OnRangeDisplay?.Invoke(false);
            spriteRen.sprite = null;
            cursor.sprite = cursorSprite;
        }

        private bool placeable = false;

        public void UpdateSprite(Sprite seed, bool canBeP = false)
        {
            if (seed)
            {
                IsFruit = canBeP;
                spriteRen.sprite = seed;

                transform.position = cursor.transform.position;

                cursor.sprite = spriteRen.sprite;
                placeable = true;
            }
            else
            {
                placeable = false;
                ResetSprite();
            }
        }

        public void ChangeSprite(Sprite seed)
        {
            if (seed)
            {
                spriteRen.sprite = seed;
                transform.position = cursor.transform.position;

                cursor.sprite = spriteRen.sprite;
                placeable = false;
            }
        }

        private void Update()
        {
            if (placeable)
                CheckPlaceables();
            else if (spriteRen.sprite != null)
            {
                CheckForPlants();
            }
        }

        private void CheckForPlants()
        {
            if (mouse == Vector2.zero)
                return;

            Node n = node.NodeFromInput(mouse);

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

        private void CheckPlaceables()
        {
            if (mouse == Vector2.zero)
                return;
            if (spriteRen.sprite != null)
            {
                Node n = node.NodeFromInput(mouse);

                if (n != null && n != lastnode)
                {
                    lastnode = n;
                    transform.position = n.worldPosition;
                }
                OnRangeDisplay?.Invoke(true);
                displayRange.DisplayTheRange(n);

                if (!IsFruit)
                    spriteRen.enabled = n?.TowerPlaceAble() == true;
                else
                    spriteRen.enabled = n?.FruitPlaceable() == true;
            }
        }

        private void Awake()
        {
            spriteRen = GetComponent<SpriteRenderer>();
            displayRange = GetComponent<DisplayRange>();
        }

        private void Start()
        {
            node = GetComponent<NodeFinder>();
        }
    }
}