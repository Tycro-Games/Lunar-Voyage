using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class GameObjectParentSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject waterPrefab = null;

        [SerializeField]
        private float rangeToSpawn = 5.0f;

        public void Spawn()
        {
            Instantiate(waterPrefab, (Vector2)transform.position + Random.insideUnitCircle * rangeToSpawn, Quaternion.identity, transform);
        }
    }
}