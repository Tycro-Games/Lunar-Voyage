using System.Collections;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class FireUntill : MonoBehaviour, IFireRater
    {
        private TreeShoot treeShoot = null;

        public IEnumerator Wait ()
        {
            yield return new WaitUntil (() => treeShoot.NullProjectile ());
        }

        private void Awake ()
        {
            treeShoot = GetComponent<TreeShoot> ();
        }
    }
}