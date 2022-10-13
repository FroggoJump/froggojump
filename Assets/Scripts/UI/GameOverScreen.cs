using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public  TextMeshProUGUI distanceMoveText, flycountsText,highscore;

    public static float distanceMove, flycounts;

    private void Start()
    {
        //distanceMove = 0;
    }

    private void Update()
    {
        distanceMoveText.text = distanceMove.ToString() + " Points";
        flycountsText.text = flycounts.ToString() + " Flies";
        highscore.text = Points.highScore.ToString();
    }

    public static void Setup(int distance, int flycount)
    {
        distanceMove = distance;
        flycounts = flycount;        
    }
}
