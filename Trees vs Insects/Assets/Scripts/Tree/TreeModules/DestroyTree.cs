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
        private IEnumerator Destroy()
        {
            gameObject.SetActive(false);
            
            EnemyManager.SetSpace();
            yield return null;
            Destroy(gameObject);
            
            

        }
        public virtual void TakeDG(int dg)
        {
            hp -= dg;
            if (hp <= 0)
                DestroyTheTree();
        }
    }
}