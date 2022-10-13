using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fpsDisplay : MonoBehaviour
{
    public Text fpsCounter;
    float time=0.4f;
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.4f)
        {
            int fps = Mathf.RoundToInt(1 / Time.unscaledDeltaTime);
            fpsCounter.text = fps.ToString();
            time = 0;
        }
       
    }
}
