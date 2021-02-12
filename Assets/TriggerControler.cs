using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControler : MonoBehaviour
{
    public bool nearObj = false;
    public PorteController porte;
    public bool cartouche = true;
    public AudioSource audioButton;

    // Update is called once per frame
    void Update()
    {
        // detecte la colision
        if (nearObj)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            // detecte la touche
            if (Input.GetKeyDown(KeyCode.E))
            {
                audioButton.Play();
                if (cartouche)
                {
                    porte.Interact();
                    this.cartouche = !this.cartouche;
                }
                
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
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
