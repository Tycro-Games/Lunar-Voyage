using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class Explode : BaseRangeSearch
    {
        [SerializeField]
        private int DAMAGE = 100000;

        public void Boom ()
        {
            Collider[] colliders = new Collider[256];
            int count = Physics.OverlapSphereNonAlloc (transform.position, range, colliders, enemies);

            if (count != 0)
            {
                for (int i = 0; i < count; i++)
                {
                    colliders[i].GetComponent<EnemyAI> ().TakeDamage (DAMAGE);
                }
            }
        }
    }
}