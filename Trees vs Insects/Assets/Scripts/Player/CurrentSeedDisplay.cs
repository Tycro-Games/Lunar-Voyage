using Bogadanul.Assets.Scripts.Tree;
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
        private SpriteRenderer spriteRen = null;

        private Camera cam;

        public void MoveSprite (InputAction.CallbackContext ctx)
        {
            Vector2 mouse = ctx.ReadValue<Vector2> ();
            if (mouse == Vector2.zero)
                return;
            if (spriteRen.sprite != null)
            {
                Node n = node.NodeFromInput (mouse);
                if (n?.Placeable () == true)
                {
                    transform.position = n.worldPosition;
                }
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
            cam = Camera.main;
            spriteRen = GetComponent<SpriteRenderer> ();
        }

        private void OnDisable ()
        {
            TreePlacer.OnBuyCheck -= ResetSprite;
        }

        private void OnEnable ()
        {
            TreePlacer.OnBuyCheck += ResetSprite;
        }

        private void Start ()
        {
            node = GetComponent<NodeFinder> ();
        }
    }
}