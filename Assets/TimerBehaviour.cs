using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerBehaviour : MonoBehaviour
{
    public TextMeshProUGUI text;
    private float startTime;
    private bool started;
    // Start is called before the first frame update
    void Start()
    {
        startTimer();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString();
            string secondes = (t % 60).ToString("f1");
            text.text = minutes + ":" + secondes;
        }
        else return;
    }
    public void startTimer()
    {
        started = true;
    }
    public void stopTimer()
    {
        started = false;
        text.color = Color.cyan;
    }
}
