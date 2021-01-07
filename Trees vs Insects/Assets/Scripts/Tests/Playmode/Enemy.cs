using System.Collections;
using System.Collections.Generic;
using Bogadanul.Assets.Scripts.Enemies;
using Bogadanul.Assets.Scripts.Utility;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Enemy
    {
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use `yield return
        // null;` to skip a frame.
        [UnityTest]
        public IEnumerator EnemyWithEnumeratorPasses ()
        {
            var g = new GameObject ();
            var par = g.AddComponent<EnemyParentChecker> ();
            yield return null;
        }
    }
}