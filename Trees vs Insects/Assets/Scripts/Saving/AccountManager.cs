using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Saving
{
    public class AccountManager : MonoBehaviour
    {
        public static SaveData saveAccounts;

        private void Awake()
        {
            LoadData();
        }

        [ContextMenu("Save Data")]
        public void SaveData()
        {
            var data = JsonUtility.ToJson(saveAccounts);
            PlayerPrefs.SetString("GameData", data);
        }

        [ContextMenu("Load Data")]
        private void LoadData()
        {
            var data = PlayerPrefs.GetString("GameData");
            saveAccounts = JsonUtility.FromJson<SaveData>(data);
        }

        private void OnDisable()
        {
            SaveData();
        }
    }
}