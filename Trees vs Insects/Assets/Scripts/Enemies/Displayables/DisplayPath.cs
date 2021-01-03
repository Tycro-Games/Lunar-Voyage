using Bogadanul.Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class DisplayPath : MonoBehaviour
    {
        [SerializeField]
        private GameObject sprite = null;

        private GameObject[] sprites;

        [SerializeField]
        private int count = 128;

        private int lasti = 0;

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
            sprites = new GameObject[count];
            for (int i = 0; i < count; i++)
            {
                GameObject s = Instantiate (sprite, transform);
                s.SetActive (false);
                sprites[i] = s;
            }
        }
    }
}