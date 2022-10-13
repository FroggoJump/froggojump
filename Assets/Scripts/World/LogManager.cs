using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogManager: MonoBehaviour
{
    public static HorizontalLog log;
    public static GameObject canvas;
    static float coolDown;
    public static void LogAction(int position)
    {
        if (coolDown>=0.3f)
        {
            log.ChangePosition(position);
            Debug.Log("S");
        }
    }
    private void Update()
    {
        if(TouchInput.touchInput.enabled == true)
        {
            coolDown = 0;
        }
        else
        {
            coolDown += Time.deltaTime;

        }
    }
    private void Awake()
    {
        canvas = GetComponentInChildren<Canvas>().gameObject;
        canvas.SetActive(false);
    }

}
