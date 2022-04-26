using Bogadanul.Assets.Scripts.Tree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Bogadanul
{
    public class MoveStartToTree : MonoBehaviour
    {
        [SerializeField]
        private float speed = 10.0f;
        [SerializeField]
        private UnityEvent OnEnd;
        private void Start()
        {
            StartCoroutine(MoveToAncient());
        }
        private IEnumerator MoveToAncient()
        {
            Vector2 pos = FindObjectOfType<AncientTreeSpaceChecker>().transform.position;
            while ((Vector2)transform.position != pos)
            {
                transform.position = Vector2.MoveTowards(transform.position, pos, Time.deltaTime * speed);
                yield return null;
            }
            OnEnd?.Invoke();
        }
    }
}
