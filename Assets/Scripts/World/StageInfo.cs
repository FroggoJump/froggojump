using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageInfo : MonoBehaviour
{
    [SerializeField]
    Points pointsRef;

    [SerializeField]
    FlyManager flies;

    
    private void Start()
    {
        int savedPoints= PlayerPrefs.GetInt("savedpoints");
        StartCoroutine(UpdatePoints(savedPoints));
        
    }

    private void OnEnable()
    {
         PlayerPrefs.SetInt("virtualLevel",SceneManager.GetActiveScene().buildIndex);

    }

    IEnumerator UpdatePoints(int points)
    {

        yield return new WaitForEndOfFrame();
        Points.distanceUnit+=points;
        pointsRef.Distance();
        PlayerPrefs.SetInt("savedpoints",0);
        int savedFlies = PlayerPrefs.GetInt("savedflies");
        if(savedFlies > 0)
        {
            FlyManager.count= savedFlies;
        }
        flies.UpdateScore();
        PlayerPrefs.SetInt("savedflies", 0);

    }
}



