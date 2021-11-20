using Bogadanul.Assets.Scripts.Player;
using System.Collections;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public interface IEnemyAI
    {
        void Init (Transform Target, Gridmanager grid);
        void TakeDamage (int dg);
    }
}