using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvPRespawn : MonoBehaviour
{
    [SerializeField] PvPManager pvpManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            pvpManager.NextFrogger();
        }
    }
}
