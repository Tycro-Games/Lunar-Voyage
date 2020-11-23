using UnityEngine;
using System.Collections;

namespace Bogadanul.Assets.Scripts.Tree
{
    public interface ITreeRecon
    {
        bool CheckDist (BoxCollider col);

        BoxCollider CheckSorounding ();
    }
}