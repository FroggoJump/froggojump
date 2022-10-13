using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChallangesCentral : MonoBehaviour
{

	Challange[] challanges;


	private void Awake()
	{
        challanges = GetComponentsInChildren<Challange>();
		LoadGame();
		UpdateCanvas();
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
