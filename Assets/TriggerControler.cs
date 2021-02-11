using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControler : MonoBehaviour
{
    public bool nearObj = false;
    public PorteController porte;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(nearObj);
        // detecte la colision
        if (nearObj)
        {
            //change color
            // detecte la touche
            if (Input.GetKeyUp(KeyCode.E))
            {
                porte.Open();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D gameObj)
    {
        nearObj = true;
    }

    void OnTriggerExit2D(Collider2D gameObj)
    {
        nearObj = false;
    }
}
