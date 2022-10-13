using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Points : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI distanceMoved;
    //[SerializeField]  GameObject uiRewards;
    public static int distanceUnit = 0, highScore = 0 ;
    float t;
    bool desactive = false;
   
    private void Start()
    {
        distanceUnit = 0;
        highScore = PlayerPrefs.GetInt("HighScore", highScore);
        
    }
    private void Update()
    {
        t += Time.deltaTime;   
    }

    private void OnEnable()
    {
        FrogController.OnFroggoLand += Distance;
        FrogController.OnFroggoJump += TimeReset;
        FrogController.OnFroggoLand += UiReward;
        FrogController.OnFroggoLand += UiRewardDisable;
    }
    private void OnDisable()
    {
        FrogController.OnFroggoLand -= Distance;
        FrogController.OnFroggoJump -= TimeReset;
        FrogController.OnFroggoLand -= UiReward;
        FrogController.OnFroggoLand -= UiRewardDisable;

        // FrogController.OnFroggoLand -= UiRewardDisable;

    }

   

    public void Distance()
    {
        //t = 0;
        if (t > 0.1f && t <= 1)
        {
            distanceUnit += 250;
        }
        else if (t > 1 && t < 1.8f)
        {
            //UiRewards();
            distanceUnit = distanceUnit + 400;
        }
        else if (t >= 1.8f && t < 2)
        {
            distanceUnit = distanceUnit + 1000;

            //print("3");
        }
        else if (t >= 2 && t < 2.4f)
        {
            //desactive = true;
            distanceUnit = distanceUnit + 1500;
        }
        else if (t >= 2.4f)
        {
            desactive = true;
            distanceUnit = distanceUnit + 3000;
        }

        distanceMoved.text = "pts " + distanceUnit.ToString();
        t = 0;
        HighScore();
    }
    public void UiReward()
    {
        if (desactive == true)
        {
            UiRewards.Activate();
            desactive = false;
        }
    }

    public void UiRewardDisable()
    {
        Invoke("UiRewardD", 0.49f);
    }
    public void UiRewardD()
    {

        UiRewards.Deactivate();

    }

    void HighScore()
    {

        if (distanceUnit > highScore)
        {
            PlayerPrefs.SetInt("HighScore", distanceUnit);
        }
    }
    void TimeReset()
    {
        t = 0;
    }
    
}
