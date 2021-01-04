using UnityEngine;
using System.Collections;
using Bogadanul.Assets.Scripts.Player;
using System.Collections.Generic;

namespace Bogadanul.Assets.Scripts.Tree
{
    public interface ITreeRecon
    {
        bool CheckDist (BoxCollider col);

        BoxCollider CheckForEnemies ();

        List<Node> GetNodeRange (Node pos);
    }
}