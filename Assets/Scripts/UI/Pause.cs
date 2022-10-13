using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseButton, pauseMenu;

    public delegate void GamePaused();
    public static event GamePaused OnGamePause;
    public delegate void GameResume();
    public static event GameResume OnGameResume;
    public void PauseBut()
    {
        if(OnGamePause != null)
        {
            OnGamePause();

        }
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        if(OnGameResume!= null)
        {
            OnGameResume();

        }
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }
    

    public void Restart()
    {
        Time.timeScale = 1f;
        FrogCentral.frog.gameObject.GetComponentInParent<Rigidbody>().useGravity = false;
        FrogCentral.frog.gameObject.GetComponentInParent<Rigidbody>().velocity= Vector3.zero;
        ScreenManager.FadeScreen();
        GameStats.Instance.VirtualLevel = 1;
        Invoke("ChangeScene", 0.35f);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void PvPMainMenu()
    {
        PlayerPrefs.DeleteKey("FrogScore");
        PlayerPrefs.DeleteKey("BestFrog");

        PlayerPrefs.DeleteKey("SecondScore");
        PlayerPrefs.DeleteKey("SecondFrog");

        SceneManager.LoadScene(1);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
