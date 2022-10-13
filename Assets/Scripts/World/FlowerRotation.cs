using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1.5f;
    [SerializeField] float rotationTime = 0f;
    [SerializeField] float rotatorCoolDown = 0f;
    [SerializeField] Color canJump;
    [SerializeField] Color stop;
    bool activate;
    float timer = 0f;
    float timerRotator = 0f;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            if (activate)
            {
                timer += Time.deltaTime;

                if (timer <= rotationTime)
                {
                    transform.Rotate(0, rotationSpeed, 0);
                    GetComponent<Outline>().OutlineColor = stop;
                    other.gameObject.GetComponentInParent<FrogController>().DeActivateJump();
                    FrogCentral.frog.gameObject.GetComponentInParent<FrogController>().CancelJump();


                }

                if (timer >= rotationTime)
                {
                    other.gameObject.GetComponentInParent<FrogController>().gameObject.transform.rotation = Quaternion.identity;
                    GetComponent<Outline>().OutlineColor = canJump;
                    other.gameObject.GetComponentInParent<FrogController>().ActivateJump();
                    activate = false;
                }
            }


        }
    }
   
    private void OnEnable()
    {
        FrogController.OnFroggoLand += Cancel;

    }
    private void OnDisable()
    {
        FrogController.OnFroggoLand -= Cancel;

    }
    void Cancel()
    {
        if (activate)
        {
            FrogCentral.frog.gameObject.GetComponentInParent<FrogController>().DeActivateJump();
            FrogCentral.frog.gameObject.GetComponentInParent<FrogController>().CancelJump();
        }


    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            activate = true;
            collision.transform.parent = transform;
            collision.gameObject.GetComponent<WorldMovement>().enabled = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent= null;
            collision.gameObject.GetComponent<WorldMovement>().enabled = true;
            collision.gameObject.GetComponentInParent<FrogController>().ActivateJump();
            activate=false;

        }
    }

}
