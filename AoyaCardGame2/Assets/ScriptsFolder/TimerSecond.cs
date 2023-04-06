using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerSecond: MonoBehaviour
{
    public class timeEvent: UnityEvent<int> { };
    timeEvent timechanged = new timeEvent();

    // Start is called before the first frame update
    void Start()
    {
        int timeMyTime = 0;

        timechanged.AddListener( timeMyTime =>
        {
            Debug.Log("Time is " + timeMyTime );
        }
            ); 

        StartCoroutine(PrintEverySecond(timeMyTime ));
    }

   IEnumerator PrintEverySecond(int time)
    {
        time++;
        timechanged.Invoke(time);
        yield return new WaitForSeconds(1);
        StartCoroutine(PrintEverySecond (time ));
    }

    
}
