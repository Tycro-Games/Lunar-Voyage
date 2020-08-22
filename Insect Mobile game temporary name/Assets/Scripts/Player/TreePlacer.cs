using UnityEngine;

public class TreePlacer : MonoBehaviour
{
    private Raycaster raycaster;
    private CheckPlacer checkPlacer;
    private void Start()
    {
        checkPlacer = GetComponent<CheckPlacer>();
        raycaster = GetComponent<Raycaster>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            checkPlacer.CheckToPlace(raycaster.Raycast(Input.mousePosition));
        }
    }




}
