using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Saving
{
    [Serializable]
    public struct SaveData
    {
        public Account CurrentAccount;
        public List<Account> savedAccounts;
    }

    [Serializable]
    public struct Account
    {
        public string name;
        public string currentLevel;

        public Account(string Name, string CurrentLevel)
        {
            name = Name;
            currentLevel = CurrentLevel;
        }
    }
}