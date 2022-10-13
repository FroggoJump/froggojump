using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Piranha : MonoBehaviour
{

    public Transform point;
    Vector3 maxPoint;
    Vector3 minPos;
    [Range(0f, 2f)]
    public float speed;
     Vector3 rotation;
    float multiplier=1;
    [SerializeField] Transform p;
    [SerializeField] Animator animator;

    [SerializeField]Transform minHorizontalPos;
    [SerializeField] Transform maxHorizontalPos;
    bool flip;
    Transform horizontalPos;
    bool up=true;


    private void Awake()

    {
        horizontalPos = maxHorizontalPos;
        minPos = transform.position;
        maxPoint = point.position;
    }
    private void Update()
    {
       
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, point.position.y, transform.position.z), speed * multiplier*Time.deltaTime );
        transform.position = Vector3.Lerp(transform.position, new Vector3(horizontalPos.position.x, transform.position.y, horizontalPos.position.z), speed * multiplier * Time.deltaTime/2);
        //transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed/0);
        if (transform.position.y >= (maxPoint.y - 0.8f))
        {
            point.position = new Vector3(point.position.x, minPos.y, point.position.z);
            multiplier = 4;
            if (flip == true)
            {
                flip = false;

            }
            else
            {
                flip = true;

            }
            animator.SetBool("Attack", false);

        }
        if (transform.position.y >= (maxPoint.y - 1.2f))
        {
            transform.DORotate(new Vector3(45, 180, 0), 0.6f);

            if (flip)
            {
                transform.DORotate(new Vector3(45, 180, 0), 0.6f);


            }
            else
            {
                transform.DORotate(new Vector3(45, 0, 0), 0.6f);


            }

        }

        if (transform.position.y >= (maxPoint.y - maxPoint.y * 0.9)&&point.position.y==maxPoint.y)
        {
            animator.SetBool("Attack",true);
        }
       

        if (transform.position.y <= minPos.y + 0.5f)
        {
            point.position = new Vector3(point.position.x, maxPoint.y, point.position.z);
            multiplier = 2;
            if (flip)
            {
                horizontalPos = minHorizontalPos;
                transform.DORotate(new Vector3(-45, 180, 0), 0.3f);


            }
            else
            {
                transform.DORotate(new Vector3(-45, 0, 0), 0.3f);

                horizontalPos = maxHorizontalPos;

            }

        }



    }

  
}
