using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickUpManager : MonoBehaviour
{
    public static GameObject image;
    public static TMP_Text text;
    private void Awake()
    {
        image = GetComponentInChildren<AnyObject>().gameObject;
        text = GetComponentInChildren<TMP_Text>();
        image.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }
    public static void UpdateSalvavidas()
    {
        if (Frog.currentShield >= 1)
        {
            image.gameObject.SetActive(true);
            text.gameObject.SetActive(false);
            Salvavidas.salvavidas.SetActive(true);
            if (Frog.currentShield >= 2)
            {
                text.gameObject.SetActive(true);
                text.text = Frog.currentShield.ToString();
            }
        }
        else
        {
            image?.gameObject.SetActive(false);
            text?.gameObject.SetActive(false);
            Salvavidas.salvavidas?.SetActive(false);
        }
    }   
}
