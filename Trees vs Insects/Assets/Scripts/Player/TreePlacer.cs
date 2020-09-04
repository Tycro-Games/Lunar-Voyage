using UnityEngine;

public class TreePlacer : MonoBehaviour, ICurrentSeedDisplay<GameObject>
{
    [SerializeField]
    private GameObject currentTree = null;

    private Raycaster raycaster;
    private CheckPlacerPath checkPlacer;

    private void Start()
    {
        checkPlacer = GetComponent<CheckPlacerPath>();
        raycaster = GetComponent<Raycaster>();
    }
    public void Place()
    {
        if (currentTree != null)
            checkPlacer.CheckToPlace(raycaster.Raycast(Input.mousePosition), currentTree);
    }

    public void UpdateSprite(GameObject seed)
    {
        currentTree = seed;
    }
}
