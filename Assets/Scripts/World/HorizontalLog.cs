using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HorizontalLog : MonoBehaviour
{
    
    [SerializeField] Transform[] pos;
    Transform player;
    int actualPosition = 1;
 
    float time = 0;
    // Update is called once per frame
    void Update()
    {
        time += 0;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.transform;
            LogManager.log = this;
            LogManager.canvas.gameObject.SetActive(true);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LogManager.canvas.gameObject.SetActive(false);
            LogManager.log = null;

        }
    }

    public void ChangePosition(int position)
    {
        if ((actualPosition + position)<=2 && (actualPosition + position) >= 0)
        {
            actualPosition += position;


            player.transform.DOMoveZ(pos[actualPosition].position.z, 0.5f);

            //player.position = pos[actualPosition].position;

        }

    }

    
}
