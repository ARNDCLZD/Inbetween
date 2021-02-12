using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public TimerBehaviour timer;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        timer.startTimer();
    }
    public void QuitGame()
    {
        Debug.Log("Fin du game");
        Application.Quit();
    }
}
