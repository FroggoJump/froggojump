using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoJumpPickUp : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            PickUp();
        }
    }

    void PickUp()
    {
        
        GetComponentInParent<AutomaticJump>().enabled = true;
        Destroy(gameObject);
    }
}
