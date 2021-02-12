using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaquePressionControler : MonoBehaviour
{
    public bool nearObj = false;
    public PorteController porte;

    // Update is called once per frame
    void Update()
    {
        // detecte la colision
        if (nearObj)
        {
            //change color
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void OnTriggerEnter2D(Collider2D gameObj)
    {
        if(gameObj.tag == "Player")
        {
            nearObj = true;
            porte.Interact();
        }
        
    }

    void OnTriggerExit2D(Collider2D gameObj)
    {
        if (gameObj.tag == "Player")
        {
            nearObj = false;
            porte.ReverseInteract();
        }
    }
}
