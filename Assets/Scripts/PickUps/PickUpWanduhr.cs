using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWanduhr : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SpeedController.ReduceTemporal();
            PickUp();
        }
    }

    private void PickUp()
    {
        Invoke("RespawnPickUp", 20);
        gameObject.SetActive(false);
    }

    private void RespawnPickUp()
    {
        gameObject.SetActive(true);
    }
}
