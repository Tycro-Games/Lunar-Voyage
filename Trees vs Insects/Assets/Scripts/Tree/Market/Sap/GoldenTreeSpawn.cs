using System.Collections;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class GoldenTreeSpawn : MonoBehaviour
    {
        [SerializeField]
        private GameObject waterPrefab = null;

        public void Spawn ()
        {
            Instantiate (waterPrefab, transform.position, Quaternion.identity, transform);
        }
    }
}