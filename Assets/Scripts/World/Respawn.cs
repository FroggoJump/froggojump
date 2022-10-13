using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    CameraFollow_DragAndShot camera;
    int distance = 0, flys = 0;
    public delegate void GameEnd();
    public static event GameEnd OnGameOver;
    public bool deadByTrigger = true;
    public bool water;
    Collider player;
    private void Start()
    {
        camera = GetCamera.camera.GetComponent<CameraFollow_DragAndShot>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && deadByTrigger)
        {
            player = other;

            if (Frog.currentShield > 0 && water)
            {
                ShieldProtection(other);
            }
            else
            {
                GameOver();
            }

        }
    }

    public  void ReloadLevel()
    {
        //ScreenManager.FadeScreen();
        GameStats.Instance.VirtualLevel = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   
    public void GameOver()
    {
        DisplayGameScreen();
        GameStats.Instance.VirtualLevel = 1;

    }

    void DisplayGameScreen()
    {
        distance = Points.distanceUnit;
        flys = FlyManager.count;
        GameOverScreen.Setup(distance, flys);
        Time.timeScale = 0f;
        if (OnGameOver != null)
        {
            OnGameOver();
        }
    }

    public void ShieldProtection(Collider other)
    {
        Frog.nextPos = SalvavidasController.spawnPos.transform.position;
        camera.ForceMovement();
        if (Frog.currentShield > 0)
        {
            Frog.currentShield--;
        }
        PickUpManager.UpdateSalvavidas();
        other.transform.parent.position = SalvavidasController.spawnPos.transform.position;
    }
}
