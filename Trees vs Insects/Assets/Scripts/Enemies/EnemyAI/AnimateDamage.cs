using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemies.EnemyAI
{
    public class AnimateDamage : MonoBehaviour
    {
        private SpriteRenderer sprite;
        private MaterialPropertyBlock _propBlock;

        [SerializeField]
        private AnimationCurve FadeFadeout;

        private bool IsAnimating = false;

        [SerializeField]
        private float speed = 3.0f;

        private void Start()
        {
            sprite = GetComponent<SpriteRenderer>();
            _propBlock = new MaterialPropertyBlock();
            sprite.GetPropertyBlock(_propBlock);
        }

        public void ChangeColor()
        {
            if (!IsAnimating)
                StartCoroutine(Changecolor());
        }

        private IEnumerator Changecolor()
        {
            IsAnimating = true;
            float currentValue = _propBlock.GetFloat("_Alpha");
            float startTime = Time.time;
            while (currentValue < 1)
            {
                currentValue += FadeFadeout.Evaluate(Time.time - startTime) * speed;
                _propBlock.SetFloat("_Alpha", currentValue);
                sprite.SetPropertyBlock(_propBlock);
                yield return null;
            }
            startTime = Time.time;
            while (currentValue > 0)
            {
                currentValue -= FadeFadeout.Evaluate(Time.time - startTime) * speed;
                _propBlock.SetFloat("_Alpha", currentValue);
                sprite.SetPropertyBlock(_propBlock);
                yield return null;
            }
            IsAnimating = false;
        }
    }
}