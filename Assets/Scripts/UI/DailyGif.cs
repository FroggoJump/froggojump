using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyGif : MonoBehaviour
{
    int flies = 0;
    void Start()
    {
        flies = PlayerPrefs.GetInt("Coins");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public   void Gif()
    {
        PlayerPrefs.SetInt("Coins", 100);
    }
}
