using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QualityChange : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] int quality;
    void Start()
    {
        quality = PlayerPrefs.GetInt("qualityNumber", 2);
        dropdown.value = quality;
        ChangeQuality();
    }

    public void ChangeQuality()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("qualityNumber", dropdown.value);
        quality = dropdown.value;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
