using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blumen : MonoBehaviour
{
    private int spacePress;
    private int kPress;

    public float startTime, stopTime, timer;
    bool isTimerRunning;

    // Start is called before the first frame update
    void Start()
    {
        spacePress = 0;
        kPress = 0;
        isTimerRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer = stopTime + (Time.time - startTime);
        Debug.Log("Overall" + timer);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePress++;
            Debug.Log("Space pressed " + spacePress);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            TimerStart();
            //Debug.Log(startTime);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            kPress++;
            Debug.Log("K pressed " + kPress);
        }
    }

    void TimerStart()
    {
        if (isTimerRunning)
        {
            startTime = Time.time;
        }
       
    }

    void TimerStop()
    {
        if (isTimerRunning)
        {
            stopTime = Time.time;
        }
       
    }

    void TimerReset()
    {
        //timer = startTime = stopTime = 0.0f;
        
        timer = 0.0f;
        startTime = 0.0f;
        stopTime = 0.0f; 
    }
}
