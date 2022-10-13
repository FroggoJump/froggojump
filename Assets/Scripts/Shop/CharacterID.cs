using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class CharacterID : MonoBehaviour
{
    public int iD=0;
    List<int> ids = new List<int>();
    [SerializeField] GameObject button;
    bool active = false;
    int j;

    [Header("Characters")]
    [SerializeField] GameObject Unlock;
    [SerializeField] GameObject character;
    [SerializeField] GameObject tono;


    [SerializeField]  Animator animator;

    private void Start()
    {
        ids = PlayerPrefsExtra.GetList<int>("IdCharacter");
    }

    private void Update()
    {
        for (int i = 0; i < ids.Count; i++)
        {
            j = ids[i];


            if (j == iD) // comprueba que los id sean los mismo 
            {
                Animatons();// carga el metodo 

            }

        }
    }

    public void Animatons()
    {
        animator.Play("Unlock");
    }
    public void Lonad()
    {
        
        tono.SetActive(false);
        button.GetComponent<Image>().enabled =true;
        Unlock.GetComponent<Image>().enabled =false;
        character.SetActive(true);
        active= true;
        

       // button.GetComponent<Button>().enabled = true;
    }

    public void Default()
    {
        tono.SetActive(true);
        character.SetActive(false);
       
    }

    public void Check()
    {
        button.GetComponent<Image>().enabled = true;
        Unlock.GetComponent<Image>().enabled = false;
        Animatons();
    }


    
   
}
