using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpriteRendererRandom : MonoBehaviour
    {
        [SerializeField]
        private int limitNumber;

        private SpriteRenderer sprite;

        public static byte spriteOrder = 0;

        private void Start()
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = spriteOrder % limitNumber;
            spriteOrder++;
        }
    }
}