﻿using Bogadanul.Assets.Scripts.Tree;
using UnityEngine;
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

        public void MoveSprite (InputAction.CallbackContext ctx)
        {
            mouse = ctx.ReadValue<Vector2> ();
        }

        public void ResetSprite ()
        {
            spriteRen.sprite = null;

            cursor.sprite = cursorSprite;
        }

        public void UpdateSprite (Sprite seed, bool canBeP = false)
        {
            if (seed)
            {
                canBePlaced = canBeP;
                spriteRen.sprite = seed;

                transform.position = cursor.transform.position;

                cursor.sprite = spriteRen.sprite;
            }
            else
            {
                ResetSprite ();
            }
        }

        private void Update ()
        {
            if (mouse == Vector2.zero)
                return;
            if (spriteRen.sprite != null)
            {
                Node n = node.NodeFromInput (mouse);

                if (n != null)
                {
                    transform.position = n.worldPosition;
                }
                displayRange.DisplayTheRange (n);
                if (!canBePlaced)
                    spriteRen.enabled = n?.Placeable () == true;
                else
                    spriteRen.enabled = n?.CanBePlaced () == true;
            }
        }

        private void Awake ()
        {
            spriteRen = GetComponent<SpriteRenderer> ();
            displayRange = GetComponent<DisplayRange> ();
        }

        private void Start ()
        {
            node = GetComponent<NodeFinder> ();
        }
    }
}