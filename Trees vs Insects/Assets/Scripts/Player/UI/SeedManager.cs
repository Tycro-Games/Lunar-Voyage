using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

namespace Bogadanul.Assets.Scripts.Player
{
    public class SeedManager : MonoBehaviour
    {
        private Transform[] SeedPlace;

        [SerializeField]
        private float speed = 1;

        private Dictionary<GameObject, Vector2> seeds = new Dictionary<GameObject, Vector2>();

        private int index = 0;

        private int countChild;

        private void Start()
        {
            countChild = transform.childCount;
            SeedPlace = new Transform[countChild];

            for (int i = 0; i < transform.childCount; i++)
                SeedPlace[i] = transform.GetChild(i);
        }

        private void ShiftList(GameObject seed)
        {
            seeds.Remove(seed);
            List<GameObject> seedObj = seeds.Keys.ToList();
            seedObj.Sort((p1, p2) => p1.transform.position.x.CompareTo(p2.transform.position.x));
            for (int i = 0; i < seedObj.Count; i++)
            {
                StartCoroutine(MoveSeed(seedObj[i].transform, SeedPlace[i].transform.position));
            }
        }

        public void AddSeed(GameObject seed)
        {
            if (seeds.ContainsKey(seed))
            {
                StartCoroutine(MoveSeed(seed.transform, seeds[seed]));
                ShiftList(seed);
                index--;
            }
            else if (index < countChild)
            {
                seeds.Add(seed, seed.transform.position);

                StartCoroutine(MoveSeed(seed.transform, SeedPlace[index++].transform.position));
            }
        }

        private IEnumerator MoveSeed(Transform currentSeed, Vector2 target)
        {
            Button button = currentSeed.GetComponent<Button>();
            button.interactable = false;
            while ((Vector2)currentSeed.position != target)
            {
                currentSeed.position = Vector2.MoveTowards(currentSeed.position, target, Time.deltaTime * speed);
                yield return null;
            }
            button.interactable = true;
        }
    }
}