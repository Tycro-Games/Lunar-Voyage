using Bogadanul.Assets.Scripts.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Saving
{
    public class AccountManager : MonoBehaviour
    {
        public static SaveData saveAccounts;
        public static Action<Account> OnAccountChange;
        public static Action<List<Account>> OnAccountsList;
        public static Action<string> OnLastLevel;
        public static AccountManager account;
        [SerializeField]
        private UnityEvent OnNoAccounts;
        [SerializeField]
        private UnityEvent OnFirstStart;


        private void Start()
        {
            if (account == null) { 
                account = this;
                OnFirstStart?.Invoke();
        }
            else
                Destroy(gameObject);
            DontDestroyOnLoad(this);
            LoadData();
        }
        [ContextMenu("Save Data")]
        public void SaveData()
        {
            saveAccounts.CurrentAccount.currentLevel = SceneManager.GetActiveScene().name;
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
            OnAccountChange?.Invoke(saveAccounts.CurrentAccount);
        }
        public void LoadLevel()
        {
            GetComponent<SceneChange>().LoadSceneSi(saveAccounts.CurrentAccount.currentLevel);
        }
        public void CreateAccount(string nameAccount)
        {
            Account newAccount = new Account(nameAccount,"");
            saveAccounts.savedAccounts.Add(newAccount);
            OnAccountsList?.Invoke(saveAccounts.savedAccounts);
            saveAccounts.CurrentAccount = newAccount;
            OnAccountChange?.Invoke(newAccount);
        }
        

    }
}