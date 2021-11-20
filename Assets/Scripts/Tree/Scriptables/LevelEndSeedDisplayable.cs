using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    [CreateAssetMenu(fileName = "new Seed Displayable", menuName = "Create/new UiSeedSiplayable")]
    public class LevelEndSeedDisplayable : ScriptableObject
    {
        public Sprite icon;

        public string description;
        public GameObject collectable;
    }
}