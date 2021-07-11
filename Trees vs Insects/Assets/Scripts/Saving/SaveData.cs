using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Saving
{
    [Serializable]
    public struct SaveData
    {
        public Account currentAcount;
        public List<Account> savedAccounts;
    }

    [Serializable]
    public struct Account
    {
        public string name;
        public int currentLevel;
    }
}