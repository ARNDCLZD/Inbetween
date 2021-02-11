using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControler : MonoBehaviour
{
    public bool nearObj = false;

    // Update is called once per frame
    void Update()
    {
        // detecte la colision
        if (nearObj)
        {
            // detecte la touche
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("OK");
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
