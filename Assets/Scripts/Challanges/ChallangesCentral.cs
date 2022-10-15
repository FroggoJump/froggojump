using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;
using System;

public class ChallangesCentral : MonoBehaviour
{

	public Challange[] challanges;
	public static ChallangesCentral instance;
	public int currentDay;

	private void Awake()
	{
		CheckChallanges();

    }
	void CheckChallanges()
	{
        if (PlayerPrefs.HasKey("cDay"))
        {
            currentDay = PlayerPrefs.GetInt("cDay");

        }
        else
        {
            currentDay = 1;
            PlayerPrefs.SetInt("cDay", currentDay);
        }
        Instantiate(Resources.Load($"Day_{currentDay.ToString()}"), this.transform);
        instance = this;
        challanges = GetComponentsInChildren<Challange>();
        StartCoroutine(UpdateChallanges());
    }
    
	IEnumerator UpdateChallanges()
	{
		yield return new WaitForEndOfFrame();
        LoadGame();
        UpdateCanvas();
    }
	private void OnEnable()
	{
		TimeManager.NextDay += NextChallanges;
		TimeManager.CurrentDay += KeepWaiting;
	}
	private void OnDisable()
	{
		TimeManager.NextDay -= NextChallanges;
		TimeManager.CurrentDay -= KeepWaiting;
	}

	public void NextChallanges()
	{
		print("It's next day");
        if (currentDay < 30)
		{
            currentDay++;
            PlayerPrefs.SetInt("cDay", currentDay);

        }	
        UIController.instance.timeLeftChallenges.gameObject.SetActive(false);
		StopAllCoroutines();
		Destroy(this.gameObject.transform.GetChild(0).gameObject);
		CheckChallanges();

    }
    public void KeepWaiting(double seconds)
	{
        double secondsLeft = seconds;
        double hours = Math.Floor(secondsLeft / 3600);
        secondsLeft = secondsLeft % 3600; 
        double mins = Math.Floor(secondsLeft / 60);
		UIController.instance.timeLeftChallenges.text = $"{hours} hours {mins} minutes ";
		UIController.instance.timeLeftChallenges.gameObject.SetActive(true);
    }
    public void SaveGame()
	{
		foreach(Challange challange in challanges)
        {
			PlayerPrefs.SetInt(challange.ChallangeInfo.id, challange.activation);

			PlayerPrefs.SetInt(challange.ChallangeInfo.idQuest, challange.claimed);
			Debug.Log(challange.claimed);

		}
		PlayerPrefs.Save();
	}
	void LoadGame()
	{
		
	   foreach (Challange challange in challanges)
		{
			if (PlayerPrefs.HasKey(challange.ChallangeInfo.id))
			{
				challange.activation=PlayerPrefs.GetInt(challange.ChallangeInfo.id);
				challange.claimed = PlayerPrefs.GetInt(challange.ChallangeInfo.idQuest);
                if (challange.activation >= 1)
                {
					challange.completed = true;
                }

			}
		}
			
		
		
	}

    public  void UpdateReward()
    {
        for (int i = 0; i < challanges.Length; i++)
        {
			if (challanges[i].quest.isClaimed)
			{
				challanges[i].Claim();
			}
		}
    }

    public void UpdateCanvas()
    {
		for (int i = 0; i < challanges.Length; i++)
		{
			challanges[i].quest.UpdateTitle(challanges[i].ChallangeInfo.challangeName);
			challanges[i].quest.UpdateDescription(challanges[i].ChallangeInfo.description);
			challanges[i].quest.UpdateReward(challanges[i].ChallangeInfo.reward.ToString());
            if (challanges[i].activation >= 1)
            {
				challanges[i].quest.Complete();

			}
			if (challanges[i].claimed >= 1)
			{
				challanges[i].quest.Claim();

			}

		}
	}
}
