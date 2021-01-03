using System.Collections;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class TreeShotNoTarget : TreeShootBase, ITreeShoot
    {
        [HideInInspector]
        public Vector2 dir;

        private IProjectileNoTarget projectileNoT;

        public override IEnumerator Shooting (Transform target)
        {
            CanShoot = false;

            instance = Instantiate (projectileObject, transform.position, Quaternion.identity, transform);
            projectileNoT = CacheProjectile<IProjectileNoTarget> (instance);
            projectileNoT.Init (dir);
            yield return StartCoroutine (fireRater.Wait ());
            CanShoot = true;
            Destroy (instance, 10);
        }
    }
}