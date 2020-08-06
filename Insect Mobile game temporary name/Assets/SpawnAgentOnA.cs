using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAgentOnA : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab=null;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.A))
        {
            Instantiate (prefab, transform.position, Quaternion.identity);
        }
    }
}
