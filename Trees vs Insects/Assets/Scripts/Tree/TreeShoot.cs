using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeShoot : MonoBehaviour, ITreeShoot
{
    [SerializeField]
    private GameObject projectileObject = null;

    private IProjectile Currentprojectile = null;
    private IFireRater fireRater = null;

    private GameObject instance = null;

    public bool CanShoot { get; private set; } = true;

    public void CacheProjectile (GameObject projectileObject)
    {
        Currentprojectile = projectileObject.GetComponent<IProjectile> ();
    }

    public bool NullProjectile ()
    {
        return instance == null ? true : false;
    }

    private void Awake ()
    {
        fireRater = GetComponent<IFireRater> ();
    }

    private void Start ()
    {
        CacheProjectile (projectileObject);
    }

    public void Shoot (Transform target)
    {
        if (CanShoot)
            StartCoroutine (Shooting (target));
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
}