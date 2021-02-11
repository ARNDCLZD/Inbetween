using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControler : MonoBehaviour
{
    public bool nearObj = false;
    public PorteController porte;
    private bool pressed = false;

    // Update is called once per frame
    void Update()
    {
        // detecte la colision
        if (nearObj)
        {
            // detecte la touche
            if (Input.GetKeyDown(KeyCode.E))
            {
                pressed = !pressed;
                if (!pressed) porte.Open();
                else porte.Close();
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
