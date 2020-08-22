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
#if UNITY_ANDROID
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
               heckPlacer.CheckToPlace(raycaster.Raycast(Input.mousePosition));
            }
        }
#endif
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            checkPlacer.CheckToPlace(raycaster.Raycast(Input.mousePosition));
        }
#endif
    }




}
