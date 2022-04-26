using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

namespace Assets.Scripts.Saving
{
    public class AccountSelect : MonoBehaviour
    {
        private TMP_Dropdown AccountNames;
        private string currentName;

        private void ChangeCurrentName(Account account)
        {
            AccountNames.captionText.text = account.name;
            AccountNames.options[0].text = account.name;
            currentName = account.name;
        }

        private void SetListOfAccounts(List<Account> accounts)
        {
            AddOptions(accounts.Count);
            for (int i = 0; i < accounts.Count; i++)
                foreach (TMP_Dropdown.OptionData data in AccountNames.options)
                {
                    if (accounts[i].name == currentName)
                        continue;
                    data.text = accounts[i++].name;
                }
        }

        private void AddOptions(int max)
        {
            while (AccountNames.options.Count < max)
            {
                AccountNames.options.Add(new TMP_Dropdown.OptionData());
            }
            int i = 0;
            while (AccountNames.options.Count > max)
            {
                AccountNames.options.RemoveAt(i++);
            }
        }

        private void Awake()
        {
            AccountNames = GetComponent<TMP_Dropdown>();
            AccountManager.OnAccountChange += ChangeCurrentName;
            AccountManager.OnAccountsList += SetListOfAccounts;
        }

        private void OnDisable()
        {
            AccountManager.OnAccountChange -= ChangeCurrentName;
            AccountManager.OnAccountsList -= SetListOfAccounts;
        }
    }
}