using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CursorController : MonoBehaviour
{
    [SerializeField]
    private float smooth = 5.0f;

    private Vector2 velocity = Vector2.zero;

    private Transform cursorTransform = null;
    private void Start()
    {
        cursorTransform = transform;
        Cursor.visible = false;
    }
    private void Update()
    {
        transform.position = Vector2.SmoothDamp(transform.position, MousePosition(), ref velocity, smooth);
    }

    public Vector2 MousePosition()
    {
        Vector2 CursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        return CursorPos;
    }


}