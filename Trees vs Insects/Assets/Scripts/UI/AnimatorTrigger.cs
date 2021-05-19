using Bogadanul;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class AnimatorTrigger : MonoBehaviour
    {
        private Animator anim = null;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void TriggerAnimatorFade()
        {
            anim.SetTrigger("Fadeout");
        }

        private void OnEnable()
        {
            EndLevel.BeforeCoolDown += TriggerAnimatorFade;
        }

        private void OnDisable()
        {
            EndLevel.BeforeCoolDown -= TriggerAnimatorFade;
        }
    }
}