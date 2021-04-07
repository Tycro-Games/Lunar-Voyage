using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemies.Movement
{
    public class FlipSprite : MonoBehaviour
    {
        private bool isRight = false;

        private void ChangeSprite()
        {
            isRight = !isRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
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