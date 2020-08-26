using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeShoot : MonoBehaviour, ITreeShoot
{
    [SerializeField]
    private GameObject projectileObject = null;
    private IProjectile projectile = null;
    [SerializeField]
    private float fireRate = .25f;
    public void CacheProjectile(GameObject projectileObject)
    {
        projectile = projectileObject.GetComponent<IProjectile>();
    }
    private void Start()
    {
        CacheProjectile(projectileObject);
    }
    public IEnumerator Shoot(Transform target)
    {
        while (target != null)
        {
            GameObject instance = Instantiate(projectileObject, transform.position, Quaternion.identity, transform);
            CacheProjectile(instance);
            projectile.Init(target);

            yield return new WaitForSeconds(fireRate);

            Destroy(instance, 5.0f);
        }
    }
}
