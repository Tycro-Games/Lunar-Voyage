using System;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class AncientTreeOnDestroy : MonoBehaviour
    {
        public void OnTreeReach ()
        {
            Debug.Log ("tree has taken damage");
        }
    }
}