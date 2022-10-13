using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UiRewards : MonoBehaviour
{
  
    //[SerializeField] Image fly;
    
    [SerializeField] List<string> text1 = new List<string>();
    [SerializeField] TextMeshProUGUI rewards;
    static GameObject uiTexts;
    float timer = 0.49f;
    // Start is called before the first frame update
    void Awake()
    {
        uiTexts = this.gameObject;
        Deactivate();
      
    }

    // Update is called once per frame
    void Update()
    {
    
        timer += Time.deltaTime;
       
        if (timer >0.49f)
        {    
           RandomizeText();
           
        }
    }

   
   

    public static void Activate()
    {

        uiTexts.SetActive(true);

    }
    public static void Deactivate()
    {
    
        uiTexts.SetActive(false);
    }


    public void RandomizeText()
    {
        rewards.fontSize = 90;
        int j = Random.Range(0, text1.Count);
        rewards.text = text1[j].ToString();
        timer = 0;
        rewards.transform.position = new Vector2(Random.Range(Screen.width - Screen.width * 0.2f,450 ), Random.Range(0, Screen.height - Screen.height * 0.1f));

        
        //rewards.fontSize = 90;
    }

}
