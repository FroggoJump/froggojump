using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deltethsi : MonoBehaviour
{
    int highscore;
    void Start()
    {
        highscore = PlayerPrefs.GetInt("HighScore");

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(highscore);
    }
}
