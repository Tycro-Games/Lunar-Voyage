using System;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Utility
{
    public class CursorController : MonoBehaviour
    {
        private Transform cursorTransform = null;

        [SerializeField]
        private float smooth = 5.0f;

        private Vector2 lastPos = Vector2.zero;

        public event Action<Vector3> OnMovement;

        public Vector2 MousePosition()
        {
            Vector2 mousePos = transform.position;
#if UNITY_EDITOR || UNITY_STANDALONE
            mousePos = Input.mousePosition;
            if (Input.GetMouseButtonDown(0))
                OnMovement?.Invoke(mousePos);
            return mousePos;
#endif
#if UNITY_ANDROID

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                mousePos = touch.position;

                if (touch.phase == TouchPhase.Ended)
                    OnMovement?.Invoke(mousePos);
                lastPos = mousePos;
            }
            return lastPos;
#endif
        }

        private void Update()
        {
            transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(MousePosition()), smooth * Time.unscaledDeltaTime);
        }

        private void Start()
        {
            if (Application.platform == RuntimePlatform.Android)
                GetComponentInChildren<SpriteRenderer>().enabled = false;
            cursorTransform = transform;
            Cursor.visible = false;
        }
    }
}