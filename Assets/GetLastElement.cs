using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GetLastElement : MonoBehaviour
{
    public GameObject lastElement;
    void Update()
    {
        if (!Application.isPlaying)
        {
            GetLast();
        }
        else
        {
            Destroy(this);
        }
    }

    void GetLast()
    {
        if (transform.childCount > 1)
        {
            for (int i = 0; i < transform.childCount-1; i++)
            {
                if (Vector3.Distance(transform.position, transform.GetChild(i).position) <= (Vector3.Distance(transform.position, transform.GetChild(i + 1).position)))
                {
                    lastElement = transform.GetChild(i + 1).gameObject;
                }
                else
                {
                    lastElement = transform.GetChild(i).gameObject;
                }
            }
        }
        else
        {
            lastElement= transform.GetChild(0).gameObject;
        }
        
       
    }

}
