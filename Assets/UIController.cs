using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
   public TMP_Text actualLevel;

    private void Start()
    {
        actualLevel.text = GameStats.Instance.Level.ToString();
    }

}
