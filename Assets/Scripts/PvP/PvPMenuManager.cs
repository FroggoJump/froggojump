using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PvPMenuManager : MonoBehaviour
{
    [SerializeField] Button playButton;

    private void Start()
    {
        MenuManager.players = 0;
        MenuManager.difficulty = 0;
    }
    private void Update()
    {
        if (MenuManager.players > 0 && MenuManager.difficulty > 0)
        {
            playButton.gameObject.SetActive(true);
        }
        else
        {
            playButton.gameObject.SetActive(false);
        }
    }
}
