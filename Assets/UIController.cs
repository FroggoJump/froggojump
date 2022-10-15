using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
   public TMP_Text actualLevel;
   public TMP_Text timeLeftChallenges;
    public static UIController instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        actualLevel.text = GameStats.Instance.Level.ToString();
    }

}
