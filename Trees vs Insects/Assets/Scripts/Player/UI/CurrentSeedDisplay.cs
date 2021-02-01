﻿using Bogadanul.Assets.Scripts.Tree;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Bogadanul.Assets.Scripts.Player
{
    public class CurrentSeedDisplay : MonoBehaviour, ICurrentSeedDisplay<Sprite>
    {
        [SerializeField]
        private SpriteRenderer cursor = null;

        [SerializeField]
        private Sprite cursorSprite = null;

        private NodeFinder node;
        private TreePlacer Placer;
        private SpriteRenderer spriteRen = null;

        private DisplayRange displayRange = null;

        public void MoveSprite (InputAction.CallbackContext ctx)
        {
            Vector2 mouse = ctx.ReadValue<Vector2> ();
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
                spriteRen.enabled = n?.Placeable () == true;
            }
        }

        public void ResetSprite ()
        {
            spriteRen.sprite = null;

            cursor.sprite = cursorSprite;
        }

        public void UpdateSprite (Sprite seed)
        {
            if (seed)
            {
                spriteRen.sprite = seed;

                transform.position = cursor.transform.position;

                cursor.sprite = spriteRen.sprite;
            }
            else
            {
                ResetSprite ();
            }
        }

        private void Awake ()
        {
            Placer = FindObjectOfType<TreePlacer> ();
            spriteRen = GetComponent<SpriteRenderer> ();
            displayRange = GetComponent<DisplayRange> ();
        }

        private void Start ()
        {
            node = GetComponent<NodeFinder> ();
        }
    }
}