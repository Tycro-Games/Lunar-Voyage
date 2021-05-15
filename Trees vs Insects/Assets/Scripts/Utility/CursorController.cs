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
            return Camera.main.ScreenToWorldPoint (Input.mousePosition);
        }

        private void Update ()
        {
            transform.position = Vector2.Lerp (transform.position, MousePosition (), smooth * Time.unscaledDeltaTime);
        }

        private void Start ()
        {
            cursorTransform = transform;
            Cursor.visible = false;
        }
    }
}