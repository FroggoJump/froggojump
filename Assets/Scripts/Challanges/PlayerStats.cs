using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    static float eatenFlies;
    static float jumpAmount;
    static float totalPoints;

    public static float EatenFlies { get => eatenFlies; }
    public static float JumpAmount { get => jumpAmount;}
    public static float TotalPoints { get => totalPoints;}

    private void Start()
    {
        eatenFlies = PlayerPrefs.GetInt("statsflies");
        jumpAmount = PlayerPrefs.GetFloat("statsjumps");
        totalPoints = PlayerPrefs.GetFloat("statspoints");

        PlayerPrefs.SetFloat("statsflies", 0);
        PlayerPrefs.SetFloat("statsjumps",0);
        PlayerPrefs.SetFloat("statspoints",0);
    }
    private void OnEnable()
    {
        FlyPoints.OnFlySquashed += FillEatenFlies;
        FrogController.OnFroggoJump+= FillJumpAmount;
        Respawn.OnGameOver += WriteResults;
    }
    private void OnDisable()
    {
        FlyPoints.OnFlySquashed -= FillEatenFlies;
        FrogController.OnFroggoJump -= FillJumpAmount;
        Respawn.OnGameOver -= WriteResults;

    }

    public void FillEatenFlies()
    {
        eatenFlies += 1;

    }
    public void FillJumpAmount()
    {
        jumpAmount += 1;
    }
  

    void WriteResults()
    {
    }
}
