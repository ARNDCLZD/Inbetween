using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControler : MonoBehaviour
{
    public bool nearObj = false;
    public PorteController porte;
    public bool cartouche = true;

    // Update is called once per frame
    void Update()
    {
        // detecte la colision
        if (nearObj)
        {
            //change color clickable
            // detecte la touche
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (cartouche)
                {
                    porte.Interact();
                    this.cartouche = !this.cartouche;
                }
                
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
