using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    public  int[,] shopItems = new int[7, 7];
    [SerializeField] int coins;
    [SerializeField] TextMeshProUGUI CoinsTXT;
    [SerializeField] AudioSource audiosource;
    public bool isPurchase;
    [SerializeField] AudioClip[] clips;
    [SerializeField] Slider  soundEffectsSlider;
    //ButtonInfo buttonInfo;
    [SerializeField] GameObject image;
    float  soundEffectsFloat;
    // [SerializeField] GameObject Inventory;
    // AudioManager audioManager;
    GameObject ButtonRef;

      List<int> characters = new List<int>();
      List<int> id = new List<int>();
    void Start()
    {
        soundEffectsFloat = PlayerPrefs.GetFloat("soundEffectpref");
        soundEffectsSlider.value = soundEffectsFloat;
        coins = PlayerPrefs.GetInt("Coins");
        CoinsTXT.text = "X" + coins.ToString();
        characters = PlayerPrefsExtra.GetList<int>("IdCharacter");
       
        //ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;
        shopItems[1, 5] = 5;
        shopItems[1, 6] = 6;
        

        //Price
        shopItems[2, 1] = 100;
        shopItems[2, 2] = 150;
        shopItems[2, 3] = 200;
        shopItems[2, 4] = 500;
        shopItems[2, 5] = 600;
        shopItems[2, 6] = 700;
        
        
        isPurchase = false;
        
    }

    private void Update()
    {
        audiosource.volume = soundEffectsSlider.value;
        // PlayerPrefs.DeleteAll();
    }


    public void Buy()
    {
        ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];//resta las moscas
            ButtonRef.GetComponent<ButtonInfo>().PriceTxt.text = "purchased".ToString();
            ButtonRef.GetComponent<ButtonInfo>().PriceTxt2.text = "purchased".ToString();// cambia los textos 
            PlayerPrefs.SetInt("Coins", coins);// guarda las moscas restantes
            //PlayerPrefs.SetInt("Id", shopItems[1, ButtonRef.GetComponent<ButtonInfo>().ItemID]);
            CoinsTXT.text = "X" + coins.ToString();// muestra la cantidad de moscas
            characters.Add(ButtonRef.GetComponent<ButtonInfo>().ItemID);//en esta lista se agrega el Id del cometico comprado
            PlayerPrefsExtra.SetList("IdCharacter", characters);// se guarda
            id.Add(shopItems[1, ButtonRef.GetComponent<ButtonInfo>().ItemID]);//guardo el id que tiene el objeto en la tienda 
            PlayerPrefsExtra.SetList("Id", id);// se guarda
            isPurchase = true;// se usa para comprobar una condicion en el buttonInfo
                              // ButtonRef.GetComponent<Button>().enabled = true
            audiosource.clip = clips[1];
            audiosource.Play();
            ButtonRef.GetComponent<ButtonInfo>().button.GetComponent<Button>().enabled = false;
        }
        else// pasa si la cantidad de moscas no alcanza para comprar el item
        {
            image.SetActive(true);// muestra un mensaje 
            ButtonRef.GetComponent<ButtonInfo>().button.GetComponent<Button>().enabled = true; 
            audiosource.clip = clips[0];
            audiosource.Play();
        }
        
    }

   
}
