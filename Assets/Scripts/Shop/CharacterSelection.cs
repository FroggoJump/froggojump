using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterSelection : MonoBehaviour
{
    [Header("CharactersPrefabs")]
    public List<GameObject> characters = new List<GameObject>();

    List<int> ids = new List<int>();
    List<int> CharacterCount = new List<int>();

    [SerializeField] TextMeshProUGUI select;
    int selectecCharacter = 0;
   // public GameObject A1;
    //public Animator A2;
   
    int j=0;
    int k=0;

    private void Start()
    {
        //int id = PlayerPrefs.GetInt("id");
        if (!PlayerPrefs.HasKey("selectedCharacter")) selectecCharacter = 0;// condicion para verificar si tengo algun dato guardado
        else Load();
        selectecCharacter = j;

    }
     void Update()
    {
       // Load();
        
        ids = PlayerPrefsExtra.GetList<int>("IdCharacter");
        CharacterCount = PlayerPrefsExtra.GetList<int>("Id");// se actualiza las listas 
        


    }

  

   

    private void Load()
    {
       selectecCharacter = PlayerPrefs.GetInt("selectedCharacter",selectecCharacter);// se obtiene  el  ultimo personaje selecionado 
        //id = PlayerPrefs.GetInt("Id");   
    }

   public  void Click()
   {
        j = 0;
        for (int i = 0; i < ids.Count; i++)
        {
            j = ids[i];
            GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;//busca el ultimo objeto que se le dio click 

            if (j == ButtonRef.GetComponent<CharacterID>().iD) // comprueba que los id sean los mismo 
            {
                ButtonRef.GetComponent<CharacterID>().Lonad();// carga el metodo 
                selectecCharacter = ButtonRef.GetComponent<CharacterID>().iD;//guarda el id del personaje seleccionado 
                StartGame();// carga el metodo
               
            }
            print("ajkshnbdi;as");// momento de crisis :v

        }




    }
    public void StartGame()
    {

        PlayerPrefs.SetInt("selectedCharacter", selectecCharacter);// guarda el personaje 
        //select.text = "Selected".ToString();
        //SceneManager.LoadScene(1, LoadSceneMode.Single);
    } 
    public void Default()
    {

        selectecCharacter = 0;// obtiene el personaje defauult
        StartGame();
        print("ajsb");
    }

}
