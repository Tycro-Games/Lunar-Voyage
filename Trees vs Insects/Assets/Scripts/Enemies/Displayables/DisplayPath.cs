﻿using Bogadanul.Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class DisplayPath : DisplayStuff
    {
        public void Display (List<Node> nodes)
        {
            UpdateDisplays (nodes);
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

        public void UpdateDisplays (List<Node> nodes)
        {
            Reset ();
            displayPathManager.AddPaths (nodes);
        }

        private void OnDisable ()
        {
            EnemyManager.OnNoSpace -= Display;
        }

        private void OnEnable ()
        {
            EnemyManager.OnNoSpace += Display;
        }

        private void Awake ()
        {
            MakeObjects ();
            displayPathManager = new DisplayPathManager ();
        }
    }
}