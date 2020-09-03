using UnityEngine;

public class TreePlacer : MonoBehaviour
{
    private Raycaster raycaster;
    private ICheckPlacer checkPlacer;
    private void Start()
    {
        checkPlacer = GetComponent<ICheckPlacer>();
        raycaster = GetComponent<Raycaster>();
    }
    public void Place()
    {

        checkPlacer.CheckToPlace(raycaster.Raycast(Input.mousePosition));
    }




}
