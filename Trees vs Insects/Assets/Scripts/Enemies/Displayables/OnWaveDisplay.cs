using Bogadanul.Assets.Scripts.Player;
using System.Collections;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class OnWaveDisplay : DisplayStuff
    {
        private WaveSystem wave;

        public void Display ()
        {
            UpdateDisplays ();
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
            foreach (EnemySpawner trace in wave.currenSelection)
                displayPathManager.AddPaths (trace.GetComponent<TracePathCheck> ().Path);
        }

        private void Awake ()
        {
            MakeObjects ();
            displayPathManager = new DisplayPathManager ();
            wave = FindObjectOfType<WaveSystem> ();
        }
    }
}