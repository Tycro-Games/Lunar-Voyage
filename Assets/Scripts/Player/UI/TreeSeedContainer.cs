using UnityEngine;
using UnityEngine.Events;

namespace Bogadanul.Assets.Scripts.Player
{
    public class TreeSeedContainer : ContainerBase
    {
        public static TreeSeedContainer treeSeedContainer;
        private Cooldown cooldown;

        [SerializeField]
        private UnityEvent OnSelected;

        [SerializeField]
        private UnityEvent OnCantSelect;

        public static void ActivateCoolDown()
        {
            treeSeedContainer.ActivateDown();
        }

        private void OnDisable()
        {
            treeSeedSender.OnResetSeed -= Deselect;
        }

        public void OnClick()
        {
            if (Selected)
            {
                treeSeedSender.CancelCurrentSeed();
                Selected = false;
                OnCantSelect?.Invoke();
                return;
            }
            if (treeSeedSender.market.CheckPrice(treeSeed.price))
            {
                treeSeedSender.ChangeCurrentSeed(treeSeed);

                Selected = true;
                treeSeedContainer = this;
                OnSelected?.Invoke();
            }
        }

        public void ActivateDown()
        {
            if (Selected)
            {
                cooldown.ResetT();
                Selected = false;
            }
        }

        private void Awake()
        {
            cooldown = GetComponent<Cooldown>();
            cooldown.Init(treeSeed.cooldown);
        }

        private void Start()
        {
            treeSeedDisplay = GetComponent<TreeSeedDisplay>();
            treeSeedSender = GetComponentInParent<TreeSeedSender>();
            treeSeedSender.OnResetSeed += Deselect;

            Displaying();
        }
    }
}