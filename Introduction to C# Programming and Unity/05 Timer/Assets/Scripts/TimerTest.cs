using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTest : MonoBehaviour
{
    // timer test
    Timer timer;

    // time measuremet
    float startTime;

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 3;
        timer.Run();

        // save start time
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            float elapsedSeconds = Time.time - startTime;
            Debug.Log("Timer run for " + elapsedSeconds + " seconds");

            startTime = Time.time;
            timer.Run();
        }
    }
}
