using Bogadanul.Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class DisplayPath : DisplayStuff
    {
        private TracePathCheck[] tracePath;

        public void Display ()
        {
            int i = 0;
            foreach (Node node in DisplayPathManager.nodes)
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

        public void Reset ()
        {
            DisplayPathManager.Reset ();
        }

        public void UpdateDisplays ()
        {
            Reset ();
            foreach (TracePathCheck trace in tracePath)
                DisplayPathManager.AddPaths (trace.Path);
        }

        private void OnDisable ()
        {
            DisplayPathManager.OnChange -= Display;
        }

        private void OnEnable ()
        {
            DisplayPathManager.OnChange += Display;
        }

        private void Awake ()
        {
            MakeObjects ();
        }

        private void Start ()
        {
            tracePath = FindObjectsOfType<TracePathCheck> ();
        }
    }
}