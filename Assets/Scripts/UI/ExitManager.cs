using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManager : MonoBehaviour
{
    [SerializeField] GameObject exitPanel;
    
    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android )
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                exitPanel.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                exitPanel.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }


    public void Yep()
    {
        Application.Quit();
        print("quit");
    }
    public void Nop()
    {
        Time.timeScale = 1f;
    }

}
