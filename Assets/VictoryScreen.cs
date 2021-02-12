using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
   public void playAgain()
    {
        SceneManager.LoadScene(1);
    }
    public void quit()
    {
        Debug.Log("Fin du game");
        Application.Quit();
    }
}
