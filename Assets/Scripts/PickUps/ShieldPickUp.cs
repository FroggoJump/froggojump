using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickUp : MonoBehaviour
{

    public delegate void FroggoJumps();
    public static event FroggoJumps OnFroggoJump;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            PickUp();
        }
    }

    private void PickUp()
    {
        if(Frog.currentShield < Frog.maxShield)
        {
            Frog.currentShield++;
            PickUpManager.UpdateSalvavidas();
            Invoke("RespawnPickUp", 15);
            gameObject.SetActive(false);
        }
    }

    private void RespawnPickUp()
    {
        gameObject.SetActive(true);
    }
}
