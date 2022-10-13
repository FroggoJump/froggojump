using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Challange : MonoBehaviour
{
    public ChallangeInfo ChallangeInfo;
    public Quest quest;
    public abstract void Validate();
    public  bool completed;
    public int activation = 0;
    public int claimed = 0;

    protected void Complete()
    {
        completed = true;
        quest.Complete();
        this.activation = 1;
        GetComponentInParent<ChallangesCentral>().SaveGame();
        quest.showNotification();

    }

    public void Claim()
    {
        if (claimed == 0)
        {
            claimed = 1;
            completed = true;
            int tempFlies = PlayerPrefs.GetInt("Coins");
            tempFlies += ChallangeInfo.reward;
            PlayerPrefs.SetInt("Coins", tempFlies);

        }

    }
}
