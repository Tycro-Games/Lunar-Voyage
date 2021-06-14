using Bogadanul.Assets.Scripts.Enemies;
using Bogadanul.Assets.Scripts.Player;
using System.Collections;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class DestroyTree : MonoBehaviour
    {
        [SerializeField]
        protected int hp = 1;

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
            gameObject.SetActive(false);
            Destroy(gameObject, 2);
            EnemyManager.SetSpace();
            yield return null;
        }

        private IEnumerator Destroy(float time)
        {
            yield return new WaitForSeconds(time);
            gameObject.SetActive(false);
            Destroy(gameObject, 2);
            EnemyManager.SetSpace();
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