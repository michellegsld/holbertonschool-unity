using System;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Class to print the current time as player plays
public class Timer : MonoBehaviour
{
    public Text TimerText;
    public static Stopwatch timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = new Stopwatch();
        timer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan ts = timer.Elapsed;
        TimerText.text = string.Format("{0:00}:{1:00}.{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
    }
}
