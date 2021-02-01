using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    [CreateAssetMenu (fileName = "new Seed", menuName = "Create/new seed")]
    public class TreeSeed : ScriptableObject
    {
        public Sprite icon;
        public int price;
        public float cooldown;
        public Sprite sprite;
        public GameObject TreeGameObject;
        public bool canBePlacedAnywhere;
    }
}