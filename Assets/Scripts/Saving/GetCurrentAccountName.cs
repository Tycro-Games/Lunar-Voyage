using System.Collections;
using UnityEngine;
using TMPro;

namespace Assets.Scripts.Saving
{
    public class GetCurrentAccountName : MonoBehaviour
    {
        private TextMeshProUGUI text = null;

        public void ChangeText(Account account)
        {
            text.text = account.name;
        }

        private void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
            AccountManager.OnAccountChange += ChangeText;
        }

        private void OnDisable()
        {
            AccountManager.OnAccountChange -= ChangeText;
        }
    }
}