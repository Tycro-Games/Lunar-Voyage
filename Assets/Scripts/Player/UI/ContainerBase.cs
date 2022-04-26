using Bogadanul.Assets.Scripts.Tree;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Player
{
    public class ContainerBase : MonoBehaviour
    {
        public TreeSeed treeSeed = null;

        protected TreeSeedSender treeSeedSender = null;

        [SerializeField]
        protected Color selectedColor = Color.black;

        protected bool selected = false;
        protected TreeSeedDisplay treeSeedDisplay = null;

        public bool Selected
        {
            get => selected;
            set
            {
                selected = value;
                ChangeColor();
            }
        }

        public void Deselect()
        {
            Selected = false;
        }

        protected void Displaying()
        {
            treeSeedDisplay.DisplaySprite(treeSeed.icon);
            treeSeedDisplay.DisplayPrice(treeSeed.price);
        }

        protected void ChangeColor()
        {
            if (selected)
            {
                treeSeedDisplay.ChangeColor(selectedColor);
            }
            else
                treeSeedDisplay.ResetColor();
        }
    }
}