using Bogadanul.Assets.Scripts.Enemies;
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

        public RandomNumbers(float maxx, float maxy, float minx, float miny)
        {
            Maxx = maxx;
            Maxy = maxy;
            Minx = minx;
            Miny = miny;
        }
    }

    public class CheckPlacerPath : MonoBehaviour
    {
        [SerializeField]
        private RandomNumbers randomNumbers = new RandomNumbers();

        [SerializeField]
        private float multiplier = 1f;

        [SerializeField]
        private static Transform parent = null;

        private void Awake()
        {
            parent = transform;
        }

        public static bool CheckToPlace(Node cell, GameObject currentTree = null)
        {
            if (cell == null && !cell.IsWalkable)
                return false;
            GameObject currentPlace = ToSpawn(cell, currentTree);

            EnemyManager.SetSpace();
            return true;
        }

        public static bool CheckNode(Node cell)
        {
            if (!cell.IsWalkable)
                return false;
            EnemyManager.CheckSpaceForOnlyPaths(cell);
            bool ret;
            if (!EnemyManager.hasPath)
            {
                ret = false;
            }
            else
                ret = true;

            return ret;
        }

        public static GameObject Spawn(GameObject currentTree, Vector2 pos)
        {
            return Instantiate(currentTree, pos, Quaternion.identity, parent);
        }

        public void CallEnemyManager()
        {
            EnemyManager.SetSpace();
        }

        public Vector2 Pos(Node cell)
        {
            return cell.worldPosition + new Vector3(Random.Range(randomNumbers.Minx * multiplier,
                            randomNumbers.Maxx * multiplier), Random.Range(randomNumbers.Miny * multiplier,
                            randomNumbers.Maxy * multiplier),
                            0);
        }

        public static GameObject ToSpawn(Node cell, GameObject currentTree)
        {
            return Spawn(currentTree, cell.worldPosition);
        }
    }
}