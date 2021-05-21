using Bogadanul.Assets.Scripts.Player;
using Bogadanul.Assets.Scripts.Tree;
using Bogadanul.Assets.Scripts.Utility;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class PredatorAI : HealthBaseAI
    {
        private Move move = null;
        private TracePath trace = null;

        [SerializeField]
        private int damage = 500;

        private bool charging = true;

        private BoxCollider[] colliders = new BoxCollider[32];

        [SerializeField]
        private Vector2 radius = Vector2.zero;

        [SerializeField]
        private Vector2 scan = Vector2.zero;

        [SerializeField]
        private LayerMask trees = 0;

        [SerializeField]
        private LayerMask EnemyLayer = 0;

        [SerializeField]
        private UnityEvent OnEndCharge = null;

        private Transform ancientTree = null;
        private Gridmanager grid = null;
        private Collider target = null;
        private IEnumerator Move;

        public override void Init(Transform Target, Gridmanager grid)
        {
            base.Init(null, grid);
            ancientTree = Target;
            this.grid = grid;

            charging = true;
            move = GetComponent<Move>();
            trace = GetComponent<TracePath>();
            trace.IsActive = false;
            FindPrey();
        }

        private void FindPrey()
        {
            target = GetPrey();
            if (target == null)
                target = FindObjectOfType<AncientTreeOnDestroy>().gameObject.GetComponent<Collider>();

            if (Move != null)
                StopCoroutine(Move);

            Move = move.MoveTo(target.transform.position);
            StartCoroutine(Move);
        }

        public void DestroyTree(DestroyTree destroyTree)
        {
            if (destroyTree != null)
                destroyTree.TakeDG(damage);
        }

        protected override void Start()
        {
            base.Start();
        }

        private void Update()
        {
            if (charging)
            {
                Collider[] collider = new Collider[1];
                int count = Physics.OverlapBoxNonAlloc(transform.position, scan / 2, collider, Quaternion.identity, trees);
                if (count > 0)
                {
                    StartCoroutine(StopCharge(collider));
                    return;
                }
                if (target == null)
                    FindPrey();
            }
        }

        private IEnumerator StopCharge(Collider[] collider = null)
        {
            charging = false;
            //anim and stuff

            StopCoroutine(Move);
            base.Init(ancientTree, grid);
            trace.IsActive = true;
            if (collider != null)
            {
                DestroyTree(collider[0].GetComponent<DestroyTree>());

                pathfinding.FindPath();
            }
            else
            {
                pathfinding.FindPath();
            }
            yield return null;
            OnEndCharge?.Invoke();
            gameObject.layer = (int)Mathf.Log(EnemyLayer.value, 2);
        }

        private Collider GetPrey()
        {
            int count = Physics.OverlapBoxNonAlloc(transform.position, radius / 2, colliders,
                Quaternion.identity, trees);
            BoxCollider col;
            if (count > 0)
            {
                col = colliders[0];

                float currentDist = transform.Dist(col.transform.position);
                foreach (BoxCollider c in colliders)
                {
                    if (c == null)
                        continue;

                    float Dist = transform.Dist(c.transform.position);
                    if (Dist < currentDist)
                    {
                        col = c;
                        currentDist = Dist;
                    }
                }
                return col;
            }
            return null;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, new Vector2(radius.x, radius.y));
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(transform.position, new Vector2(scan.x, scan.y));
        }
    }
}