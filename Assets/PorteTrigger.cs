using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteTrigger : MonoBehaviour
{
    [SerializeField] private PorteController porte;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            porte.Open();
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            porte.Close();
        }
    }
}
