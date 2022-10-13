using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonInfo : MonoBehaviour
{
    [Header("PlayerId")]
    public int ItemID;
  
    
    [Header("Prices")]
    public TextMeshProUGUI  PriceTxt;
    public TextMeshProUGUI PriceTxt2;


    [Header("Shop")]
    [SerializeField] GameObject Shopmanager;
    public  GameObject button;


    List<int> ids = new List<int>();
    List<int> idss = new List<int>();


    private void Start()
    {
        ids = PlayerPrefsExtra.GetList<int>("IdCharacter");// obtiene la lista
    }

    void Update()
    {
        

        if (Shopmanager.GetComponent<ShopManager>().isPurchase == false && Shopmanager.GetComponent<ShopManager>().shopItems[1, ItemID] == ItemID)// condicional que me verifica si  aun no se ha comprado el objeto 
        {
            
            PriceTxt.text = "X" + Shopmanager.GetComponent<ShopManager>().shopItems[2, ItemID].ToString();
            PriceTxt2.text = "X" + Shopmanager.GetComponent<ShopManager>().shopItems[2, ItemID].ToString();// muestra los precios del objeto 
            for (int i = 0; i < ids.Count; i++)// verifica si el objeto fue comprado en una sesion anterior
            {
                int j = ids[i];
                if (j == ItemID)// si el condicional es verdadero, cambia los textos del objeto y desactiva el objeto para no ser comprado nuevamente 
                {
                    PriceTxt.text = "purchased".ToString();
                    PriceTxt2.text = "purchased".ToString();
                    button.GetComponent<Button>().enabled = false;
                }
            }
        }

        //idss.Add(ItemID);
        //PlayerPrefsExtra.SetList("Id", idss);

    }

 

}
