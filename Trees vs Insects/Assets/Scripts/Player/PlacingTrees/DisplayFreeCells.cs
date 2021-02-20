using Bogadanul.Assets.Scripts.Enemies;
using Boo.Lang;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Player
{
    public class DisplayFreeCells : DisplayStuffBase
    {
        private CurrentSeedDisplay currentSeedDisplay;
        private List<Node> nodes = new List<Node> ();

        public void DisplayPlaceable ()
        {
            //check
            if (nodes.Count == 0)
                Init ();
            //reset
            foreach (Node n in nodes.ToList ())
            {
                if (n.Ocupied == true)
                    nodes.Remove (n);
                else if (!nodes.Contains (n))
                    nodes.Add (n);
            }
            int i = 0;
            foreach (Node node in nodes)
            {
                sprites[i].SetActive (true);
                sprites[i++].transform.position = node.worldPosition;
            }
            for (; i < lasti; i++)
            {
                sprites[i].SetActive (false);
            }
            lasti = i;
        }

        private void Init ()
        {
            foreach (Node n in Gridmanager.Nodes.Keys)
            {
                if (n.Walkable)
                    nodes.Add (n);
            }
        }

        private void Start ()
        {
            MakeObjects ();
            currentSeedDisplay = GetComponentInChildren<CurrentSeedDisplay> ();
        }
    }
}