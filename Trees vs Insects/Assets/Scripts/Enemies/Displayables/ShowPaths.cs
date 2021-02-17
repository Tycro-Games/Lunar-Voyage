using Bogadanul.Assets.Scripts.Player;
using Boo.Lang;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class ShowPaths : DisplayStuff
    {
        private CurrentSeedDisplay currentSeed = null;

        public void Display (bool show = true)
        {
            if (!show)
            {
                Reset ();
            }
            else
            {
                UpdateDisplays ();
            }

            int i = 0;
            foreach (Node node in displayPathManager.nodes)
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

        public void UpdateDisplays ()
        {
            Reset ();
            foreach (GameObject trace in EnemyList.List.ToList ())
            {
                TracePath path = trace.GetComponentInChildren<TracePath> ();
                if (path != null)
                    displayPathManager.AddPaths (path.Path, false);
            }
        }

        private void OnDisable ()
        {
            currentSeed.OnRangeDisplay -= Display;
        }

        private void Awake ()
        {
            MakeObjects ();
            displayPathManager = new DisplayPathManager ();
            currentSeed = FindObjectOfType<CurrentSeedDisplay> ();
            currentSeed.OnRangeDisplay += Display;
        }
    }
}