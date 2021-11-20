using Bogadanul.Assets.Scripts.Player;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class GetRocking : MonoBehaviour
    {
        private SeedManager seedManager = null;
        private Button button = null;

        private void OnEnable()
        {
            seedManager = FindObjectOfType<SeedManager>();
            seedManager.OnFull += ActivateButton;
            seedManager.NotFull += DeactivateButton;
        }

        private void OnDisable()
        {
            seedManager.OnFull -= ActivateButton;
            seedManager.NotFull -= DeactivateButton;
        }

        private void ActivateButton()
        {
            button.interactable = true;
        }

        private void DeactivateButton()
        {
            button.interactable = false;
        }

        private void Start()
        {
            button = GetComponent<Button>();
        }
    }
}