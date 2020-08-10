using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAI : MonoBehaviour
{
    [SerializeField]
    private TreeStats treeStats=null;
    public TreeStats GetTreeStats
    {
        get => treeStats;
       
    }
    
}
