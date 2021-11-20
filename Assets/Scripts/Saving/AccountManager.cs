using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Saving
{
    public class AccountManager : MonoBehaviour
    {
        public static SaveData saveAccounts;
        public static Action<Account> OnAccountChange;
        public static Action<List<Account>> OnAccountsList;

        [SerializeField]
        private UnityEvent OnNoAccounts;

        private void Start()
        {
            DontDestroyOnLoad(this);
            LoadData();
        }

        [ContextMenu("Save Data")]
        public void SaveData()
        {
            var data = JsonUtility.ToJson(saveAccounts);
            PlayerPrefs.SetString("GameData", data);
        }

        [ContextMenu("Delete Data")]
        public void DeleteData()
        {
            PlayerPrefs.DeleteAll();
        }

        [ContextMenu("Load Data")]
        private void LoadData()
        {
            var data = PlayerPrefs.GetString("GameData");
            if (data == "")//no data
            {
                saveAccounts.savedAccounts = new List<Account>();
                OnAccountsList?.Invoke(saveAccounts.savedAccounts);
                OnNoAccounts?.Invoke();
                return;
            }
            saveAccounts = JsonUtility.FromJson<SaveData>(data);
            OnAccountsList?.Invoke(saveAccounts.savedAccounts);
            OnAccountChange?.Invoke(saveAccounts.CurrentAcount);
        }

        public void CreateAccount(string nameAccount)
        {
            Account newAccount = new Account(nameAccount);
            saveAccounts.savedAccounts.Add(newAccount);
            OnAccountsList?.Invoke(saveAccounts.savedAccounts);
            saveAccounts.CurrentAcount = newAccount;
            OnAccountChange?.Invoke(newAccount);
        }

        private void OnDisable()
        {
            SaveData();
        }
    }
}