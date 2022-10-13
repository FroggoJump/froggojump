using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public Material lineMaterial;
    public Color rightColor;
    bool onWaterlily;
    float target;
    private void Update()
    {
        if (FreePath.active)
        {
            if (onWaterlily)
            {
                lineMaterial.color = rightColor;

            }

            else
            {
                lineMaterial.color = rightColor;

            }
        }
        Frog.objectOfsset = Mathf.Lerp(Frog.objectOfsset, target, 0.0725f);

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.isTrigger)
        {

            if (other.gameObject.GetComponentInParent<WaterLily>() != null)
            {
                WaterLily water = (WaterLily)other.gameObject.GetComponentInParent<WaterLily>();

                onWaterlily = true;

                target = (int)water.type;
            }


        }
       

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.isTrigger) {


            if (other.gameObject.GetComponentInParent<WaterLily>() != null)
            {
                onWaterlily = false;
                target = 0;

            }
        }



         
        
       

    }
}
