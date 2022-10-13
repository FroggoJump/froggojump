using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PvPManager : MonoBehaviour
{
    [SerializeField] Transform startPos;
    [SerializeField] Transform worldPos;
    [SerializeField] GameObject readyOrSkip;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI frogNumber;
    [SerializeField] TextMeshProUGUI distanceMeter;
    CameraFollow_DragAndShot camera;
    public delegate void GameEnd();
    public static event GameEnd OnFinalMenu;
    private float timer = 0;
    private float timerTemp = 0;
    private int froggers = 0;
    private int frogTurn = 1;

    private void Start()
    {
        camera = GetCamera.camera.GetComponent<CameraFollow_DragAndShot>();
        PvPSettings();
        timerTemp = timer;
    }

    void Update()
    {
        Timer();
        distanceMeter.text = "" + FrogCentral.frog.transform.position.x.ToString("f0") + " mts";
    }

    void Timer()
    {
        timer -= Time.deltaTime;

        timerText.text = "" + timer.ToString("f0");

        if (timer <= 0)
        {
            timer = timerTemp;
            NextFrogger();
        }
    }

    private void PvPSettings()
    {
        switch (MenuManager.players)
        {
            case 1:
                froggers = 2;
                break;
            case 2:
                froggers = 3;
                break;
            case 3:
                froggers = 4;
                break;
            case 4:
                froggers = 5;
                break;
            case 5:
                froggers = 6;
                break;
            case 6:
                froggers = 7;
                break;
            case 7:
                froggers = 8;
                break;
        }

        switch (MenuManager.difficulty)
        {
            case 1:
                timer = 15f;
                break;
            case 2:
                timer = 30f;
                break;
            case 3:
                timer = 45f;
                break;
            case 4:
                timer = 60f;
                break;
        }
    }

    void SetHighScore()
    {
        float frogScore = FrogCentral.frog.transform.position.x;
        int bestFrog = frogTurn;
        frogTurn++;

        if (frogScore > PlayerPrefs.GetFloat("FrogScore", 0))
        {
            PlayerPrefs.SetFloat("SecondScore", PlayerPrefs.GetFloat("FrogScore", 0));
            PlayerPrefs.SetInt("SecondFrog", PlayerPrefs.GetInt("BestFrog", 0));

            PlayerPrefs.SetFloat("FrogScore", frogScore);
            PlayerPrefs.SetInt("BestFrog", bestFrog);
        }
        else if (frogScore > PlayerPrefs.GetFloat("SecondScore", 0))
        {
            PlayerPrefs.SetFloat("SecondScore", frogScore);
            PlayerPrefs.SetInt("SecondFrog", bestFrog);
        }
    }

    private void ReloadBattle()
    {
        worldPos.position = new Vector3(7.5f, 1, 0);
        FrogCentral.frog.transform.position = startPos.position;
        SpeedController.speed = 0f;
        FrogController.OnFroggoJump += SpeedController.StartSpeed;
        camera.PvPForceMovement();
        timer = timerTemp;
    }

    public void NextFrogger()
    {
        SetHighScore();

        if (frogTurn <= froggers)
        {
            Time.timeScale = 0f;
            distanceMeter.gameObject.SetActive(false);
            readyOrSkip.SetActive(true);
            frogNumber.text = frogTurn.ToString();
        }
        else if (frogTurn > froggers)
        {
            Time.timeScale = 0f;
            VSResults();
        }
    }

    public void Ready()
    {
        ReloadBattle();
        readyOrSkip.SetActive(false);
        distanceMeter.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Skip()
    {
        if (frogTurn < froggers)
        {
            frogTurn++;
            frogNumber.text = frogTurn.ToString();
        }
        else if(frogTurn >= froggers)
        {
            VSResults();
        }
    }

    public void VSResults()
    {
        if (OnFinalMenu != null)
        {
            distanceMeter.gameObject.SetActive(false);
            OnFinalMenu();
        }
    }
}
