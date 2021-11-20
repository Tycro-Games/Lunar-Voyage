using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Saving
{
    [Serializable]
    public struct SaveData
    {
        public Account CurrentAcount;
        public List<Account> savedAccounts;
    }

    [Serializable]
    public struct Account
    {
        public string name;
        public int currentLevel;

        public Account(string Name, int CurrentLevel = 0)
        {
            name = Name;
            currentLevel = CurrentLevel;
        }
    }
}