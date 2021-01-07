using Bogadanul.Assets.Scripts.Enemies;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class DestroyTree : MonoBehaviour
    {
        public void DestroyTheTree ()
        {
            Destroy (gameObject);
            EnemyManager.CheckSpace ();
        }
    }
}