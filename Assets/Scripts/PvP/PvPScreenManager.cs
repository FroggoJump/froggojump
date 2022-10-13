using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PvPScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject winnerScreen;

    private void OnEnable()
    {
        PvPManager.OnFinalMenu += GameEnd;
    }

    private void OnDisable()
    {
        PvPManager.OnFinalMenu -= GameEnd;
    }

    void GameEnd()
    {
        winnerScreen.SetActive(true);
    }
}
