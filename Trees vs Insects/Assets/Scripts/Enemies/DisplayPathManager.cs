using Bogadanul.Assets.Scripts.Enemies;
using Bogadanul.Assets.Scripts.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DisplayPathManager
{
    public static HashSet<Vector2> nodes = new HashSet<Vector2> ();

    public static event Action OnChange = null;

    public static void AddPaths (HashSet<Node> path)
    {
        HashSet<Vector2> node = new HashSet<Vector2> ();
        foreach (Node n in path)
            node.Add (n.worldPosition);
        nodes = node;
        OnChange?.Invoke ();
    }
}