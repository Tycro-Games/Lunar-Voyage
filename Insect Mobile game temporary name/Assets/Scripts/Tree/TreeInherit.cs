using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(TreeAI))]
public class TreeInherit : MonoBehaviour
{
    protected TreeAI treeAI = null;
    private void Awake ()
    {
        treeAI = GetComponent<TreeAI> ();
    }
}
