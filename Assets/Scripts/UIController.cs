using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
   public TMP_Text actualLevel;
   public TMP_Text timeLeftChallenges;
    public Quest slotQuest_1;
    public Quest slotQuest_2;
    public Quest slotQuest_3;

    public static UIController instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if (actualLevel == null) return;
        actualLevel.text = GameStats.Instance.Level.ToString();
    }

}
