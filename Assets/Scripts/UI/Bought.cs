using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bought :MonoBehaviour 
{
    //public bool isBought;
    public List<GameObject> characters = new List<GameObject>();

   public  void AddCharacter(GameObject character)
   {
        
        characters.Add(character);
        print("adafasd");
   }
}
