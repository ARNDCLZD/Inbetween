using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public GameObject spawnPoint;
    public AudioSource audio;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "deathBox")
        {
            audio.Play();
            GetComponent<PlayerController>().isSpirit = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
