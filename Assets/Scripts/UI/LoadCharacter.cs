using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadCharacter : MonoBehaviour
{
    [SerializeField] GameObject[] characterPrefabs;
    [SerializeField] Transform spawnPosition;


    [SerializeField] int selectedCharacter = 0;
    void Start()
    {
       // selectedCharacter = 0;
        if (!PlayerPrefs.HasKey("selectedCharacter")) selectedCharacter = 0;// misma verificacion que en el characterselection 
        else  Load();

        //comentar esta linea si quieres que salga solo un personaje 
        UpdateCharacter(selectedCharacter); //se carga el metodo 
    }

     public void UpdateCharacter(int selectedCharacter)
     {
        GameObject prefab = characterPrefabs[selectedCharacter];// crea un objeto que contiene al personaje selecionado 
        GameObject clone = Instantiate(prefab, spawnPosition.position,Quaternion.identity);// instancia a ese objeto creado
       
     }

    void Load()
    {
         selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");// obtiene el persoaneje selecionado 

    }

    
}
