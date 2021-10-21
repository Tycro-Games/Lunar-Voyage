using Assets.Scripts.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Bogadanul.Assets.Scripts.Player
{
    public class SeedManager : MonoBehaviour
    {
        private Transform[] SeedPlace = null;

        [SerializeField]
        private float speed = 1;

        public event Action OnFull;

        public event Action NotFull;

        public int max = 8;

        private Dictionary<GameObject, Vector2> seeds = new Dictionary<GameObject, Vector2>();

        private int index = 0;

        private void Start()
        {
            SeedPlace = new Transform[transform.childCount];

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

        public void SetRound()
        {
            for (int i = 0; i < transform.childCount; i++)
                SeedPlace[i].gameObject.SetActive(false);
            foreach (GameObject s in seeds.Keys)
            {
                Instantiate(s.GetComponent<PrefabConatiner>().Object, transform);
                Destroy(s);
            }
        }

        public IEnumerator AddSeed(GameObject seed)
        {
            if (seeds.ContainsKey(seed))//already here
            {
                yield return StartCoroutine(MoveSeed(seed.transform, seeds[seed]));
                ShiftList(seed);
                index--;
                IsFull();
            }
            else if (index < max)//add new
            {
                seeds.Add(seed, seed.transform.position);

                yield return StartCoroutine(MoveSeed(seed.transform, SeedPlace[index++].transform.position));
                IsFull();
            }
        }

        public void AddAll()
        {
            GameObject[] seeds = GameObject.FindGameObjectsWithTag("Moveable");
            if (max >= seeds.Length)
            {
                StartCoroutine(Addall(seeds));
            }
        }

        private IEnumerator Addall(GameObject[] seeds)
        {
            speed = 1000;
            foreach (GameObject seed in seeds)
            {
                yield return StartCoroutine(AddSeed(seed));
               
            }
            FindObjectOfType<GetRocking>().gameObject.GetComponent<Button>().onClick?.Invoke();
        }

        public void IsFull()
        {
            if (index >= max)
            {
                OnFull?.Invoke();
                return;
            }

            NotFull?.Invoke();
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