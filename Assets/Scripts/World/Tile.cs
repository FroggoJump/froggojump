using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Tile : MonoBehaviour
{
    public float tileLength=30;
    private Transform next;
    
  
    public Transform lastElement;

    public Transform Next { get { 
        
        if(next == null)
            {
                GetLast();
            }
        
        return next; 
        } set => next = value; }

    void GetLast()
    {
        lastElement = transform.GetChild(0);

        if (transform.childCount > 0)
        {
            if (transform.childCount > 1)
            {
                for (int i = 0; i < transform.childCount  ; i++)
                {
                    if (Vector3.Distance(transform.position, transform.GetChild(i).position) >= (Vector3.Distance(transform.position, lastElement.position)))
                    {
                        lastElement = transform.GetChild(i);
                    }

                }
            }
            else
            {
                lastElement = transform.GetChild(0);
            }
            Next = lastElement;
        }
           

    }
}
