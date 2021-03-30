using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemies.Movement
{
    public class FlipSprite : MonoBehaviour
    {
        private SpriteRenderer sprite = null;
        private bool isRight = false;

        private void Start()
        {
            sprite = GetComponent<SpriteRenderer>();
        }

        private void ChangeSprite()
        {
            isRight = !isRight;
            sprite.flipX = isRight;
        }

        public void ChangeDirection(Vector3 currentPos, Vector3 desiredPos)
        {
            if (isRight)
            {
                if (currentPos.x > desiredPos.x)
                {
                    ChangeSprite();
                }
            }
            else if (currentPos.x < desiredPos.x)
            {
                ChangeSprite();
            }
        }
    }
}