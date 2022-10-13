using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Quest : MonoBehaviour
{
  [SerializeField] TMP_Text title;
  [SerializeField] TMP_Text description;
  [SerializeField] TMP_Text reward;
  [SerializeField] Image lineImage;
  [SerializeField] Button collect;
  [SerializeField] GameObject notification;
  [SerializeField] TMP_Text notificationText;
    public bool isClaimed;

    public void showNotification()
    {

        notification.gameObject.SetActive(true);
        notificationText.text = title.text.ToString();
        Invoke("HideNotification", 4);
    }
    void HideNotification()
    {
        notification.gameObject.SetActive(false);

    }
    public void Claim()
    {
        isClaimed = true;
        collect.GetComponentInChildren<TMP_Text>().text = "Collected";
        collect.interactable = false;
    }
    public void UpdateTitle(string title)
    {
        this.title.text = title;
    }

    public void UpdateDescription(string description)
    {
        this.description.text = description;

    }
    public void UpdateReward(string reward )
    {
        this.reward.text = reward;

    }
    public void Complete()
    {
        lineImage.gameObject.SetActive(true);
        collect.gameObject.SetActive(true);
    }
}
