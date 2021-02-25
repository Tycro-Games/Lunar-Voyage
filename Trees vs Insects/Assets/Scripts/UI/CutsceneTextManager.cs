using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.UI
{
    public class CutsceneTextManager : MonoBehaviour
    {
        private List<GameObject> texts = new List<GameObject> ();
        private GameObject currentText = null;
        private int index = 1;

        public void CheckChildren ()
        {
            if (index < texts.Count)
            {
                currentText.SetActive (false);
                currentText = texts[index++];
            }
        }

        private void Start ()
        {
            for (int i = 0; i < transform.childCount; i++)
                texts.Add (transform.GetChild (i).gameObject);
            currentText = texts[0];
        }

        private void OnEnable ()
        {
            TimelineController.OnTextchange += CheckChildren;
        }

        private void OnDisable ()
        {
            TimelineController.OnTextchange -= CheckChildren;
        }
    }
}