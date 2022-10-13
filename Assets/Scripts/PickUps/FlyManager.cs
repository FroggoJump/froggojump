using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FlyManager : MonoBehaviour
{
    [SerializeField] TMP_Text flyCount;
    public static int count = 0;
    private void Start()
    {
        count = 0;
        UpdateScore();
    }

    private void OnEnable()
    {
        FlyPoints.OnFlySquashed += UpdateScore;
    }
    private void OnDisable()
    {
        FlyPoints.OnFlySquashed -= UpdateScore;

    }
    public void UpdateScore()
    {
        flyCount.text = count.ToString();
    }

   
}
