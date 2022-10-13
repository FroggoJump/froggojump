using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCheck : MonoBehaviour
{
    public List<int> ids = new List<int>();
    public List<GameObject> characters = new List<GameObject>();
    int j;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ids = PlayerPrefsExtra.GetList<int>("IdCharacter");
        ids.Sort();

        j = 0;
        for (int i = 0; i < ids.Count; i++)
        {
            j = ids[i];
         

            if (j == characters[i].GetComponent<CharacterID>().iD) // comprueba que los id sean los mismo 
            {
                characters[i].GetComponent<CharacterID>().Check();// carga el metodo 
               
            }

        }
    }
}
