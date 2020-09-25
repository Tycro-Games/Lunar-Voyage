using Bogadanul.Assets.Scripts.Grid;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Player
{
    public class NodeFinder : MonoBehaviour
    {
        private Gridmanager theGrid = null;

        public Node NodeFromPoint (Vector2 position)
        {
            return theGrid.NodeFromWorldPoint (Camera.main.ScreenToWorldPoint (position));
        }

        private void Start ()
        {
            theGrid = FindObjectOfType<Gridmanager> ();
        }
    }
}