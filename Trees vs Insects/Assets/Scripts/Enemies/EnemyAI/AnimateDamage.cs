using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Enemies.EnemyAI
{
    [System.Serializable]
    public class FloatEvent : UnityEvent<float>
    {
    }

    public class AnimateDamage : MonoBehaviour
    {
        private SpriteRenderer sprite;
        private MaterialPropertyBlock _propBlock;

        [SerializeField]
        private AnimationCurve FadeFadeout;

        private bool IsAnimating = false;

        [SerializeField]
        private float speed = 3.0f;
        [SerializeField]
        public FloatEvent OnCurrentValue=new FloatEvent();

        private void Start()
        {
            sprite = GetComponent<SpriteRenderer>();
            _propBlock = new MaterialPropertyBlock();
            sprite.GetPropertyBlock(_propBlock);
        }
        [SerializeField]
        private UnityEvent OnMax;
        [SerializeField]
        private UnityEvent OnMin;
        public void ChangeColor()
        {
            if (!IsAnimating)
                StartCoroutine(Changecolor());
        }

        private void OnEnable()
        {
            OnCurrentValue.AddListener(ChangeMaterial);
        }

        private void OnDisable()
        {
            OnCurrentValue.RemoveListener(ChangeMaterial);
        }

        private IEnumerator Changecolor()
        {
            IsAnimating = true;
            float currentValue = _propBlock.GetFloat("_Alpha");
            float startTime = Time.time;
            while (currentValue < 1)
            {
                currentValue += FadeFadeout.Evaluate(Time.time - startTime) * speed;
                if (currentValue > 1)
                    currentValue = 1;

                OnCurrentValue?.Invoke(currentValue);
                yield return null;
            }
            OnMax?.Invoke();
            startTime = Time.time;
            while (currentValue > 0)
            {
                currentValue -= FadeFadeout.Evaluate(Time.time - startTime) * speed;
                if (currentValue < 0)
                    currentValue = 0;

                OnCurrentValue?.Invoke(currentValue);
                yield return null;
            }
            IsAnimating = false;
            OnMin?.Invoke();
        }

        public void ChangeMaterial(float currentValue,SpriteRenderer sprite)
        {

            _propBlock.SetFloat("_Alpha", currentValue);
            sprite.SetPropertyBlock(_propBlock);
        }
        private void ChangeMaterial(float currentValue)
        {

            _propBlock.SetFloat("_Alpha", currentValue);
            sprite.SetPropertyBlock(_propBlock);
        }
    }
}