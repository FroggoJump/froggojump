using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenesManager : MonoBehaviour
{

    private void Awake()
    {
        if (PlayerPrefsExtra.GetBool("story") == true)
        {
            ChangeScene();
        }
        PlayerPrefsExtra.SetBool("story", true);

    }
    // Update is called once per frame
    public void ChangeScene()
    {

       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

    }
}
