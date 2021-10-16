using Bogadanul.Assets.Scripts.Player;
using System.Linq;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class ShowPaths : DisplayStuff
    {
        private CurrentSeedDisplay currentSeed = null;
        private TracePathCheck[] spawners;

        public void Display(bool show = true)
        {
            if (!show)
            {
                Reset();
            }
            else
            {
                UpdateDisplays();
            }

            int i = 0;
            foreach (Node node in displayPathManager.nodes)
            {
                sprites[i].SetActive(true);
                sprites[i++].transform.position = node.worldPosition;
            }
            for (; i < lasti; i++)
            {
                sprites[i].SetActive(false);
            }
            lasti = i;
        }

        public void UpdateDisplays()
        {
            Reset();
            foreach (GameObject trace in EnemyList.List.ToList())
            {
                if (trace != null)
                {
                    TracePath path = trace.GetComponentInChildren<TracePath>();
                    displayPathManager.AddPaths(path.Path, false);
                }
            }
            foreach (TracePathCheck trace in spawners)
            {
                if (trace != null)
                {
                    displayPathManager.AddPaths(trace.Path, false);
                }
            }
        }

        private void OnDisable()
        {
            currentSeed.OnRangeDisplay -= Display;
        }

        private void Awake()
        {
            Init();
            currentSeed = FindObjectOfType<CurrentSeedDisplay>();
            currentSeed.OnRangeDisplay += Display;
            spawners = FindObjectsOfType<TracePathCheck>();

        }
        private void Start()
        {
            Display();
        }
    }
}