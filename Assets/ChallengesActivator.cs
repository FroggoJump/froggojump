using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengesActivator : MonoBehaviour
{



    private void OnEnable()
    {
        foreach (var item in ChallangesCentral.instance.challanges)
        {
            if(!item.completed) return;
        }
        Debug.Log("All completed");
        TimeManager.instance.CompareTime();
    }
  


   
}
