using Assets.Scripts.Saving;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul
{
    public class SaveLevel : MonoBehaviour
    {
        private void Start()
        {
            FindObjectOfType<AccountManager>().SaveData();
        }
    }
}
