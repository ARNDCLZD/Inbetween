using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject spawnPoint;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "deathBox")
        {
            GetComponent<PlayerController>().isSpirit = false;
            this.transform.position = spawnPoint.transform.position;
        }
    }
}
