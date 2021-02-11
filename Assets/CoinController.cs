using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private bool nearObj = false;
    public GameObject coin;

    // Update is called once per frame
    void Update()
    {
        // detecte la colision
        if (nearObj)
        {
            coin.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D gameObj)
    {
        if(gameObj.tag == "playerSoul")
        {
            nearObj = true;
        }
    }

    void OnTriggerExit2D(Collider2D gameObj)
    {
        if (gameObj.tag == "playerSoul")
        {
            nearObj = false;
        }
    }
}
