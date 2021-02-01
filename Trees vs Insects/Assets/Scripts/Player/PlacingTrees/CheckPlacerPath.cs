﻿using Bogadanul.Assets.Scripts.Enemies;
using Bogadanul.Assets.Scripts.Player;
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

        public RandomNumbers (float maxx, float maxy, float minx, float miny)
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
        private RandomNumbers randomNumbers = new RandomNumbers ();

        [SerializeField]
        private float multiplier = 1f;

        public bool CheckToPlace (Node cell, GameObject currentTree)
        {
            if (cell == null && !cell.Walkable)
                return false;

            EnemyManager.hasPath = false;

            Vector2 pos = Pos (cell);
            GameObject currentPlace = Spawn (currentTree, pos);

            EnemyManager.CheckSpace ();

            if (!EnemyManager.hasPath)
            {
                Destroy (currentPlace);
                return false;
            }
            EnemyManager.SetSpace ();
            return true;
        }

        public GameObject Spawn (GameObject currentTree, Vector2 pos)
        {
            return Instantiate (currentTree, pos, Quaternion.identity, transform);
        }

        public void CallEnemyManager ()
        {
            EnemyManager.SetSpace ();
        }

        public Vector2 Pos (Node cell)
        {
            return cell.worldPosition + new Vector3 (Random.Range (randomNumbers.Minx * multiplier,
                            randomNumbers.Maxx * multiplier), Random.Range (randomNumbers.Miny * multiplier,
                            randomNumbers.Maxy * multiplier),
                            0);
        }
    }
}