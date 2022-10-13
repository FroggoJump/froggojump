using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LetterMovement : MonoBehaviour
{

    float amplitudeY = 6.5f;
    float omegaY = 5.0f;
    public float index;
    float offsety=0;
   
    private void Start()
    {
        offsety = transform.localPosition.y;
    }
    public void Update()
    {
        index += Time.deltaTime;
        float y = Mathf.Abs(amplitudeY * Mathf.Sin(omegaY * index));
        transform.localPosition = new Vector3(transform.localPosition.x, offsety+y, 0);
    }

}
