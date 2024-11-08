﻿using Bogadanul.Assets.Scripts.Player;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Player
{
    public class NodeFinder : MonoBehaviour
    {
        [SerializeField]
        private LayerMask layerToPlace = 0;

        private Camera cam;

        public Node NodeFromInput(Vector2 position)
        {
            if (Physics.Raycast(cam.ScreenPointToRay(position), out RaycastHit hit, 50, layerToPlace)
                &&
                hit.collider.gameObject.CompareTag("grid"))
            {
                return hit.collider.GetComponent<NodeInstance>().Nodey;
            }
            return null;
        }

        public Node NodeFromPoint(Transform trans)
        {
            Node node = null;
            Collider[] cols = new Collider[1];
            int count = Physics.OverlapBoxNonAlloc(trans.position, Vector3.zero, cols, Quaternion.identity, layerToPlace);
            if (count != 0)
                node = cols[0].gameObject.GetComponent<NodeInstance>().Nodey;
            return node;
        }

        private void Start()
        {
            cam = Camera.main;
        }
    }
}