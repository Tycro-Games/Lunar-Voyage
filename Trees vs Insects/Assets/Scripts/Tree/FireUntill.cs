using System.Collections;
using UnityEngine;

public class FireUntill : MonoBehaviour, IFireRater
{
    private TreeShoot treeShoot = null;
    private void Awake()
    {
        treeShoot = GetComponent<TreeShoot>();
    }
    public IEnumerator Wait()
    {
        yield return new WaitUntil(() => treeShoot.NullProjectile());
    }
}
