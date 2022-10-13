using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salvavidas : MonoBehaviour
{
   public static GameObject salvavidas;
    private void Awake()
    {
        salvavidas = GetComponentInChildren<AnyObject>().gameObject;
        salvavidas.SetActive(false);
    }
}
