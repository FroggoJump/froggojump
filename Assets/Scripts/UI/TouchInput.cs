using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInput : MonoBehaviour
{
    public static Image touchInput;
    private void Awake()
    {
        touchInput = GetComponent<Image>();
        Disable();
     }
    private void Update()
    {
        if (touchInput.enabled)
        {
            touchInput.rectTransform.position = Input.mousePosition;
        }
        
    }
    public static void  Enable()
    {
        touchInput.enabled = true;
    }
    public static void Disable()
    {
        touchInput.enabled = false;
    }

}
