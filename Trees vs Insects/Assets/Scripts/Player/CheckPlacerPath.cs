using Bogadanul.Assets.Scripts.Enemies;
using Bogadanul.Assets.Scripts.Grid;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Player
{
    [System.Serializable]
    internal struct RandomNumbers
    {
        public float Maxx;
        public float Maxy;
        public float Minx;
        public float Miny;
    }

    public class CheckPlacerPath : MonoBehaviour
    {
        [SerializeField]
        private RandomNumbers randomNumbers;

        public bool CheckToPlace (Node cell, GameObject currentTree)
        {
            if (!cell.walkable)
                return false;

            EnemyManager.hasPath = false;
            Vector2 pos = cell.worldPosition + new Vector3 (Random.Range (randomNumbers.Minx, randomNumbers.Maxx), Random.Range (randomNumbers.Miny, randomNumbers.Maxy), 0);
            GameObject currentPlace = Instantiate (currentTree, pos, Quaternion.identity, transform);
            EnemyManager.CheckSpace ();
            if (!EnemyManager.hasPath)
            {
                Destroy (currentPlace);
                EnemyManager.CheckSpace ();
                return false;
            }
            return true;
        }
    }
}