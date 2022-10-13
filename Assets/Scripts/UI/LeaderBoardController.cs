using UnityEngine.UI;
using LootLocker.Requests;
using TMPro;
using UnityEngine;

public class LeaderBoardController : MonoBehaviour
{
    public TMP_Text memberIDText;

    string memberID;
    int link;
    public int ID;
    int maxScores ;
    [SerializeField] TMP_Text selfName;
    [SerializeField] TMP_Text selfHighschore;
    [SerializeField] TMP_Text[] entries;
    [SerializeField] TMP_Text[] IDS;
    [SerializeField] Color color;
    [SerializeField] GameObject error;
    [SerializeField] GameObject registration;
    [SerializeField] Button sumbitButton;
    [SerializeField] GameObject error_Text;
    [SerializeField] GameObject loading_Text;
    int highscore;
    bool userRegistered;
    
    private void OnEnable()
    {
        loading_Text.SetActive(true);
        error_Text.SetActive(false);
        maxScores = entries.Length;

        userRegistered = PlayerPrefsExtra.GetBool("userRegistered");
        highscore = PlayerPrefs.GetInt("HighScore");

        memberID = PlayerPrefs.GetString("memberID");
        link = PlayerPrefs.GetInt("link");
        if (!userRegistered)
        {
            link = Random.Range(10000, 1000000000);
            PlayerPrefs.SetInt("link", link);
            registration.SetActive(true);
        }
        else
        {
           
            LootLockerSDKManager.StartSession("Player", (response) =>
            {
                if (response.success)
                {
                    UpgradeScore();
                    ShowScores();
                }
                else
                {
                    error.SetActive(true);
                }
            });

        }
       
       
    }

    public void UpgradeScore()
    {
        LootLockerSDKManager.SubmitScore(link.ToString(), highscore, ID.ToString(), memberID, response =>
        {
         
        });

    }

    public void ShowScores()
    {
        loading_Text.SetActive(true);
        selfName.text = memberID.ToString();
        selfHighschore.text = highscore.ToString();
        LootLockerSDKManager.GetScoreList(ID, maxScores, response =>
        {
            if (response.success)
            {

                LootLockerLeaderboardMember[] scores = response.items;
                loading_Text.SetActive(false);

                for (int i = 0; i < scores.Length; i++)
                {
                    entries[i].text = scores[i].score.ToString();
                    IDS[i].text = scores[i].metadata.ToString();
                    if(link.ToString()== scores[i].member_id)
                    {
                        IDS[i].color = color;
                    }

                }
                if (scores.Length < maxScores)
                {
                    for (int i = scores.Length; i < maxScores; i++)
                    {
                        entries[i].text ="";
                        IDS[i].text = "none";
                    }
                }
            }
            else
            {
                error.SetActive(true);

            }
        });
    }
    public void RegisterUser()
    {
        if (memberIDText.text.ToString().Length >= 3)
        {
            error_Text.SetActive(false);
            sumbitButton.interactable = false;
            memberID = memberIDText.text;
            PlayerPrefs.SetString("memberID", memberID);
            LootLockerSDKManager.SubmitScore(link.ToString(), highscore, ID.ToString(), memberID, response =>
            {

                if (response.success)
                {
                    registration.SetActive(false);
                    userRegistered = true;
                    PlayerPrefsExtra.SetBool("userRegistered", userRegistered);
                }
                else
                {
                    sumbitButton.interactable = true;

                    error.SetActive(true);

                }
            });

            LootLockerSDKManager.StartSession("Player", (response) =>
            {
                if (response.success)
                {
                    UpgradeScore();
                    ShowScores();
                }
                else
                {
                    error.SetActive(true);
                }
            });
        }
        else
        {
            error_Text.SetActive(true);

        }


    }
}
