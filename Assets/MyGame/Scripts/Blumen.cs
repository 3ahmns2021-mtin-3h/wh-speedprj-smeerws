using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blumen : MonoBehaviour
{
    private int spacePress;
    private int kPress;
    private bool isSpacePressed, isKPressed;

    public float startTime, stopTime, timer;
    public GameObject prefabBlume;
    public GameObject parentObj;
    private bool isTimerRunning;


    // Start is called before the first frame update
    void Start()
    {
        spacePress = 0;
        kPress = 0;
        isTimerRunning = false;
        isSpacePressed = isKPressed = false;
    }

    // Update is called once per frame
    void Update()
    {

        timer = stopTime + (Time.time - startTime);
        int seconds = (int)timer % 60;

        //Debug.Log("Overall " + timer + " sec " + seconds);

        //Methode die StopTimer ausführt für Space Press; 
        if (isTimerRunning)
        {
            if (isSpacePressed && seconds >= 1)
            {
                isSpacePressed = false;
                TimerStop();
                TimerReset();
                CreateBlumen(spacePress);
            }
            if(isKPressed && seconds >= 1)
            {
                isKPressed = false;
                TimerStop();
                TimerReset();
                //Methoden Call
            }
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePress++;
            Debug.Log("Space pressed " + spacePress);
            isSpacePressed = true;
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
        if (!isTimerRunning)
        {
            startTime = Time.time;
            isTimerRunning = true;

            Debug.Log("in Start Time " + startTime);
        }

    }

    void TimerStop()
    {
        Debug.Log("in Stop Timer");
        if (isTimerRunning)
        {
            stopTime = Time.time;
            isTimerRunning = false;
            Debug.Log("in Stop Timer " + stopTime);

        }
       
    }

    void TimerReset()
    {
        //timer = startTime = stopTime = 0.0f;
        
        timer = 0.0f;
        startTime = 0.0f;
        stopTime = 0.0f;
        Debug.Log("Timer Reset");
    }

    public void CreateBlumen(int numberBlumen)
    {
        for(int i = 0; i < numberBlumen; i++)
        {
            Instantiate(prefabBlume, new Vector2(i * 2.0f, 0), Quaternion.identity, parentObj.transform);
        }
    } 
}
