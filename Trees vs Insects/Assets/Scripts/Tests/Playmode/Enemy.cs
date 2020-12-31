using System.Collections;
using System.Collections.Generic;
using Bogadanul.Assets.Scripts.Enemies;
using NUnit.Framework;
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
            var game = new GameObject ();
            var s = game.AddComponent<EnemyAI> ();
            var h = game.AddComponent<EnemyHealth> ();

            h.Health = 100;
            yield return null;
            s.TakeDamage (5);
            // Use the Assert class to test conditions. Use yield to skip a frame.
            yield return null;
            Assert.AreEqual (95, h.Health);
        }
    }
}