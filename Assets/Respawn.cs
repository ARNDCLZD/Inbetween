using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public GameObject spawnPoint;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "deathBox")
        {
            GetComponent<PlayerController>().isSpirit = false;
            SceneManager.LoadScene("Niveau1");
        }
    }
    public void respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
