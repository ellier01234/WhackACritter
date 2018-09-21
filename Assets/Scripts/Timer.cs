using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    // display visual timer
    public TextMesh displayText;

    // starting time for the timer 
    public float timerDuration; 

    // current seconds remaining on timer 
    private float timeRemaining = 0; 

	// Use this for initialization
	void Start () {
        StartTimer();
	}
	
	// Update is called once per frame
	void Update () {
        // only process the timer if it is running
		if (IsTimerRunning())
        {
            // timer IS running, so process 

            // updated the time remaining 
            timeRemaining = timeRemaining - Time.deltaTime;

            // check if we have now run out of time 
            if (timeRemaining <= 0)
            {
                StopTimer();
            }

            // update the visual display 
            displayText.text = Mathf.CeilToInt(timeRemaining).ToString();
        }
	}

    public void StartTimer()
    {
        timeRemaining = timerDuration;
        displayText.text = Mathf.CeilToInt(timeRemaining).ToString();
    }

    // Stop the timer counting 

    public void StopTimer()
    {
        timeRemaining = 0;
        displayText.text = Mathf.CeilToInt(timeRemaining).ToString();
    }

    // is the timer currently running? 

    public bool IsTimerRunning()
    {
        if (timeRemaining != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
