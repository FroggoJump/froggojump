using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStats : MonoBehaviour
{
   
     static GameStats instance;
    public static GameStats Instance { get {

            if (instance == null)
            {
                // Find singleton of this type in the scene
                var i = GameObject.FindObjectOfType<GameStats>();

                // If there is no singleton object in the scene, we have to add one
                if (i == null)
                {
                    GameObject obj = new GameObject("Unity Singleton");
                    i = obj.AddComponent<GameStats>();

                    //Init the singleton

                    // The singleton object shouldn't be destroyed when we switch between scenes
                    DontDestroyOnLoad(obj);
                    instance = i;
                }
            }


            return instance;
        } private set => instance = value; }
    public int VirtualLevel { get => virtualLevel; set => virtualLevel = value; }
    public float ActualSpeed { get => actualSpeed;  }
    public float ActualDistance { get => actualDistance; }
    public Vector3 RelativeMove { get => relativeMove; }
    public int Level { get => level; set => level = value; }

    private float actualSpeed;
    private int virtualLevel=1;
    private int level=1;
    private float actualDistance;
    private Vector3 relativeMove;


    private void Awake()
    {
     
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        if (!PlayerPrefs.HasKey("actualLevel")) return;
        level = PlayerPrefs.GetInt("actualLevel");
    }
    
    private void OnEnable()
    {
        StageChager.Onchanged += SaveStats;
    }
    private void OnDisable()
    {
        StageChager.Onchanged -= SaveStats;
    }
    private void SaveStats()
    {
        this.actualSpeed = SpeedController.speed;
        this.actualDistance = SpeedController.distance;
        this.relativeMove = SpeedController.Move;
        virtualLevel++;
        level++;
        PlayerPrefs.SetInt("actualLevel", level);
        StartCoroutine(ForgetRings());
    }
    private void OnLevelWasLoaded(int level)
    {
       
        if (virtualLevel == 1)
        {
            StartCoroutine(ResetGameStats());

        }


    }

    IEnumerator ResetGameStats()
    {
        yield return new WaitForSeconds(1);
        PlayerPrefs.SetInt("savedRings", 0);
        Frog.currentShield = 0;
        PickUpManager.UpdateSalvavidas();


    }
    IEnumerator ForgetRings()
    {
        yield return new WaitForSeconds(1);
        PickUpManager.UpdateSalvavidas();

        if (PlayerPrefs.HasKey("savedRings"))
        {

            PlayerPrefs.SetInt("savedRings", 0);

        }



    }

}
