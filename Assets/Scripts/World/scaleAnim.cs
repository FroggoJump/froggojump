using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleAnim : MonoBehaviour
{
    float amplitudeY = 0.8f;
    float omegaY = 3.0f;
     float index;

    public void Update()
    {
        index += Time.deltaTime;
        float y = Mathf.Abs(amplitudeY * Mathf.Sin(omegaY * index))+5.5f;
        transform.localScale = new Vector3(y,  y, 1);
    }
}
