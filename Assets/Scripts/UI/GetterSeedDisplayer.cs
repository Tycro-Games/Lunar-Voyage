using Bogadanul.Assets.Scripts.Tree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class GetterSeedDisplayer : MonoBehaviour
    {
        [SerializeField]
        private LevelEndSeedDisplayable levelEndSeedDisplayable = null;

        public LevelEndSeedDisplayable LevelEndSeedDisplayable { get => levelEndSeedDisplayable; set => levelEndSeedDisplayable = value; }
    }
}