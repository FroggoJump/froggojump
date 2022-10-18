using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Newtonsoft.Json;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    private void Awake()
    {
        instance = this;
    }
    public static Action NextDay ;
    public static Action<double> CurrentDay ;
    DateTime currentTime;

   

    public void CompareTime()
    {
        currentTime = DateTime.Now;

        string output = JsonConvert.SerializeObject(currentTime);

        if (!PlayerPrefs.HasKey("savedTime"))
        {
            PlayerPrefs.SetString("savedTime", output);
            return;
        }
        string lastSaved = PlayerPrefs.GetString("savedTime");

        DateTime lastSavedTime = JsonConvert.DeserializeObject<DateTime>(lastSaved);



        var hours = ( currentTime- lastSavedTime).TotalHours;
        if (hours >= 23)
        {
            NextDay?.Invoke();
            PlayerPrefs.SetString("savedTime", output);

        }
        else
        {
            var seconds = (currentTime - lastSavedTime).TotalSeconds;
            double secondsLeft = (23* 3600) - seconds;
            CurrentDay?.Invoke(secondsLeft);
        }
    }

}
