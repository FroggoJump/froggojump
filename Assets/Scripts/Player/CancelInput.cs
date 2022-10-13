using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelInput : MonoBehaviour
{
    public static Image cancelInput;
    private void Awake()
    {
        cancelInput = GetComponent<Image>();
        Disable();
    }

    public static void Enable()
    {if(cancelInput != null)
        {
            cancelInput.enabled = true;

        }
    }
    public static void Disable()
    {
        if (cancelInput != null)
        {
            cancelInput.enabled = false;

        }
    }
}
