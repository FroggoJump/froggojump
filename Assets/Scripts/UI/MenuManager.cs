using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{

    [SerializeField] PVPAnimation m_pvp;
    [SerializeField] TMP_Dropdown pvpPlayers;
    [SerializeField] TMP_Dropdown pvpTimer;
    public static int players;
    public static float difficulty;

    private void OnGUI()
    {
        Time.timeScale = 1f;

    }
   
    public void ClickZone()
    {
        Time.timeScale = 1f;

        int level = PlayerPrefs.GetInt("virtualLevel");
        if(level >= 2)
        {
            SceneManager.LoadScene(level);

        }
        else
        {
            SceneManager.LoadScene(2);

        }
    }

    public void PvPScene()
    {
        Time.timeScale = 1f;
        m_pvp.gameObject.SetActive(true);
        m_pvp.Animate();
        Invoke("LoadPVP", 1.5f);
        this.gameObject.SetActive(false);
    }

    void LoadPVP()
    {
        SceneManager.LoadScene(5);
    }

    public void PvPMenuSettings()
    {
        players = pvpPlayers.value;
        difficulty = pvpTimer.value;
    }
}

