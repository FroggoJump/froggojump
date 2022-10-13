using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleFlyDemo : MonoBehaviour
{
    [SerializeField] Image fingerImage;
    [SerializeField] Sprite fingerPressed;
    [SerializeField] Sprite fingerNormal;
    // Start is called before the first frame update
    void Start()
    {
        Click();
    }
    void Click()
    {

        fingerImage.sprite = fingerPressed;
        Invoke("Stop", 0.2f);
    }

    void Stop()
    {
        fingerImage.sprite = fingerNormal;

        Invoke("Click", 0.2f);

    }

}
