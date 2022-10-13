using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    public GameObject playerPos;
    bool player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")&&!player)
        {
            playerPos = other.GetComponentInParent<FrogController>().gameObject;
            player = true;
            GetComponent<Collider>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            transform.position = new Vector3(playerPos.transform.position.x, 0.69f, playerPos.transform.position.z);

        }
    }
}
