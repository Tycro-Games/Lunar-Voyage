using System.Collections;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class TreeShoot : MonoBehaviour, ITreeShoot
    {
        private IProjectile Currentprojectile = null;

        private IFireRater fireRater = null;

        private GameObject instance = null;

        [SerializeField]
        private GameObject projectileObject = null;

        public bool CanShoot { get; private set; } = true;

        public void CacheProjectile (GameObject projectileObject)
        {
            Currentprojectile = projectileObject.GetComponent<IProjectile> ();
        }

        public bool NullProjectile ()
        {
            return instance == null ? true : false;
        }

        public void Shoot (Transform target)
        {
            if (CanShoot)
                StartCoroutine (Shooting (target));
        }

        private void Awake ()
        {
            fireRater = GetComponent<IFireRater> ();
        }

        private IEnumerator Shooting (Transform target)
        {
            if (target != null)
            {
                CanShoot = false;

                instance = Instantiate (projectileObject, transform.position, Quaternion.identity, transform);
                CacheProjectile (instance);
                Currentprojectile.Init (target);

                yield return StartCoroutine (fireRater.Wait ());

                CanShoot = true;

                Destroy (instance, 10.0f);
            }
        }

        private void Start ()
        {
            CacheProjectile (projectileObject);
        }
    }
}