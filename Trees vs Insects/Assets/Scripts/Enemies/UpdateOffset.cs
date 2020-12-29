using Bogadanul.Assets.Scripts.Player;
using System.Collections;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class UpdateOffset : MonoBehaviour
    {
        private NodeFinder nodeFinder = null;

        [HideInInspector]
        private Vector2 offset = Vector2.zero;

        public Vector2 Offset
        {
            get => offset;
            set
            {
                offset = value;
            }
        }

        public void UpdateOffsets ()
        {
            Node currentNode = nodeFinder.NodeFromPoint (transform);
            Offset = transform.position - currentNode.worldPosition;
        }

        public void StartPos (Vector2 pos)
        {
            //change pos

            transform.position = (Vector2)transform.position + pos;
            Offset = pos;
        }

        private void Awake ()
        {
            nodeFinder = GetComponent<NodeFinder> ();
        }
    }
}