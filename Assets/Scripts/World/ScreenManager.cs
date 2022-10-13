using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public GameObject GameOverScreen;
    public Image image;
    static Image fade;

    private void OnEnable()
    {
        Respawn.OnGameOver += GameOver;
        fade = image;
    }

    private void OnDisable()
    {
        Respawn.OnGameOver -= GameOver;
    }
    void GameOver()
    {
        GameOverScreen.SetActive(true);

    }

    public static void FadeScreen()
    {
        fade.color = StageManager.nextColor;
        fade.gameObject.SetActive(true);
        fade.DOFade(1, 0.35f);
    }
}
