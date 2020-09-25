using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    [CreateAssetMenu (fileName = "new Seed", menuName = "Create/new seed")]
    public class TreeSeed : ScriptableObject
    {
        public Sprite icon;
        public int price;
        public Sprite sprite;
        public GameObject TreeGameObject;
    }
}