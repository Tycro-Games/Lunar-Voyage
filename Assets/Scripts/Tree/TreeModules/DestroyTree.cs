using Bogadanul.Assets.Scripts.Enemies;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class DestroyTree : MonoBehaviour
    {
        [SerializeField]
        protected int hp = 1;

        [SerializeField]
        private UnityEvent OnDie;

        public virtual void DestroyTheTree()
        {
            StartCoroutine(Destroy());
        }

        public virtual void DestroyTheTreeOntime(float time)
        {
            StartCoroutine(Destroy(time));
        }

        private IEnumerator Destroy()
        {
            OnDie?.Invoke();
            gameObject.SetActive(false);
            EnemyManager.SetSpace();

            Destroy(gameObject);
            yield return null;
        }

        private IEnumerator Destroy(float time)
        {
            yield return new WaitForSeconds(time);
            OnDie?.Invoke();
            gameObject.SetActive(false);
            EnemyManager.SetSpace();

            Destroy(gameObject);
            yield return null;
        }

        public virtual void TakeDG(int dg)
        {
            hp -= dg;
            if (hp <= 0)
                DestroyTheTree();
        }
    }
}