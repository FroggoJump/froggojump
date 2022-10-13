using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PvPFinalMenu : MonoBehaviour
{
    public TextMeshProUGUI frogNumber, furtherFrog, secondNumber, secondDistance;

    private void OnEnable()
    {
        frogNumber.text = PlayerPrefs.GetInt("BestFrog").ToString();
        furtherFrog.text = PlayerPrefs.GetFloat("FrogScore").ToString("f2") + " mts";

        secondNumber.text = PlayerPrefs.GetInt("SecondFrog").ToString();
        secondDistance.text = PlayerPrefs.GetFloat("SecondScore").ToString("f2") + " mts";
    }
}
