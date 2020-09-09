using UnityEngine;
using System;
public class TreePlacer : MonoBehaviour, ICurrentSeedDisplay<GameObject>
{
    [SerializeField]
    private GameObject currentTree = null;

    private Raycaster raycaster;
    private CheckPlacerPath checkPlacer;
    public static event Action OnBuyCheck;
    private void Start()
    {
        checkPlacer = GetComponent<CheckPlacerPath>();
        raycaster = GetComponent<Raycaster>();
    }
    public void Place()
    {
        if (currentTree != null)
        {
            if (checkPlacer.CheckToPlace(raycaster.Raycast(Input.mousePosition), currentTree))
            {

                currentTree = null;
                OnBuyCheck?.Invoke();
            }

        }
    }

    public void UpdateSprite(GameObject seed)
    {
        currentTree = seed;
    }
}
