using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RandomFly : MonoBehaviour
{
    [SerializeField] Image fly;
    static GameObject panel;
    float timer = 0.8f;
    // Start is called before the first frame update
    void Awake()
    {
        panel = this.gameObject;
        Deactivate();
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;

        if(timer > 0.8f)
        {
            RandomizeFly();
        }
    }
    public static  void Activate()
    {
        panel.SetActive(true);
    }
    public static void Deactivate()
    {
        panel.SetActive(false);
    }
    public void RandomizeFly()
    {
        timer = 0;
        fly.rectTransform.anchoredPosition = new Vector2(Random.Range(0, Screen.width - Screen.width * 0.15f), Random.Range(0, Screen.height - Screen.height * 0.3f));

    }
    public void AddPoint()
    {
        FlyPoints.AddPoints(1);
    }
}
