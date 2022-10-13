using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityReductor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            ResetVelocity();
        }
    }
    


    private void ResetVelocity()
    {
        //WorldMovement.ResetSpeed();
    }
}
