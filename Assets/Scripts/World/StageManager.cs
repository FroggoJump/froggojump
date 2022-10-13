using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] Color[] colors;
    int multiplier=1;
    [SerializeField] new Light light;
    int secondMultiplier=1;
    public static Color nextColor;
    float nextIntensity;
    private void Awake()
    {
        nextColor = colors[Random.Range(0, colors.Length - 1)];
        nextIntensity = Random.Range(1.3f, 2f);
    }
    private void Update()
    {
        float max = 30 * multiplier;
        light.color = Color.Lerp(light.color, nextColor, 0.01f);
        light.intensity = Mathf.Lerp(light.intensity, nextIntensity, 0.01f);
        if (SpeedController.distance>=(max))
            {
            nextColor = colors[Random.Range(0,colors.Length-1)];
            nextIntensity = Random.Range(1.3f, 2f);
            //light.color= colors[multiplier];
            multiplier += 1;


            }
        
    }
}
