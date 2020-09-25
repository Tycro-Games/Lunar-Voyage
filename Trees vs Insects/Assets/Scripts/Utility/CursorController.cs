using UnityEngine;

namespace Bogadanul.Assets.Scripts.Utility
{
    public class CursorController : MonoBehaviour
    {
        private Transform cursorTransform = null;

        [SerializeField]
        private float smooth = 5.0f;

        private Vector2 velocity = Vector2.zero;

        public Vector2 MousePosition ()
        {
            Vector2 CursorPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

            return CursorPos;
        }

        private void FixedUpdate ()
        {
            transform.position = Vector2.SmoothDamp (transform.position, MousePosition (), ref velocity, smooth);
        }

        private void Start ()
        {
            cursorTransform = transform;
            Cursor.visible = false;
        }
    }
}