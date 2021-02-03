using Bogadanul.Assets.Scripts.Enemies;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class DestroyTree : MonoBehaviour
    {
        [SerializeField]
        protected int hp = 1;

        public virtual void DestroyTheTree ()
        {
            Destroy (gameObject);
            EnemyManager.SetSpace ();
        }

        public virtual void TakeDG (int dg)
        {
            hp -= dg;
            if (hp <= 0)
                DestroyTheTree ();
        }
    }
}