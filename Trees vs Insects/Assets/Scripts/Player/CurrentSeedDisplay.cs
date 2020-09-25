using Bogadanul.Assets.Scripts.Grid;
using Bogadanul.Assets.Scripts.Tree;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Bogadanul.Assets.Scripts.Player
{
    public class CurrentSeedDisplay : MonoBehaviour, ICurrentSeedDisplay<Sprite>
    {
        [SerializeField]
        private Transform cursor = null;

        private NodeFinder node;
        private SpriteRenderer spriteRen = null;

        public void MoveSprite (InputAction.CallbackContext ctx)
        {
            Vector2 mouse = ctx.ReadValue<Vector2> ();
            if (mouse == Vector2.zero)
                return;

            if (spriteRen.sprite != null)
            {
                Node n = node.NodeFromPoint (mouse);
                if (n.walkable)
                    transform.position = n.worldPosition;
            }
        }

        public void ResetSprite ()
        {
            spriteRen.sprite = null;

            cursor.GetChild (0).gameObject.SetActive (true);
        }

        public void UpdateSprite (Sprite seed)
        {
            spriteRen.sprite = seed;

            transform.position = cursor.position;

            cursor.GetChild (0).gameObject.SetActive (false);
        }

        private void Awake ()
        {
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