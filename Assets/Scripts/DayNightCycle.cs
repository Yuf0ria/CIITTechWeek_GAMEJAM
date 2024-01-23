using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DayNightCycle : MonoBehaviour
{
    public Volume ppv;
    public float tick;
    public float seconds;
    public int mins;
    public int hours;
    public int days = 1;
    // Start is called before the first frame update
    void Start()
    {
        ppv = gameObject.GetComponent<Volume>();
    }

    void FixedUpdate() // we used fixed update, since update is frame dependant. 
    {
        CalcTime();
    }

    public void CalcTime() // Used to calculate sec, min and hours
    {
        seconds += Time.fixedDeltaTime * tick; // multiply time between fixed update by tick

        if (seconds >= 60) // 60 sec = 1 min
        {
            seconds = 0;
            mins += 1;
        }

        if (mins >= 60) //60 min = 1 hr
        {
            mins = 0;
            hours += 1;
        }

        if (hours >= 24) //24 hr = 1 day
        {
            hours = 0;
            days += 1;
        }
        ControlPPV(); // changes post processing volume after calculation
    }

    public void ControlPPV()
    {
        if (hours >= 18 && hours < 19)
        {
            ppv.weight = (float)mins / 60;
        }
        if (hours >= 6 && hours < 7)
        {
            ppv.weight = 1 - (float)mins / 60;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
