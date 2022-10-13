using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class FadeScreen : MonoBehaviour
{
    public Image image;
    private void Start()
    {
        image.color=new Color(StageManager.nextColor.r, StageManager.nextColor.g, StageManager.nextColor.b,1);
    }
    private void OnEnable()
    {
        
        image.DOFade(0, 0.6f);
        Invoke("Deactivate", 0.61f);
    }

    public void Deactivate()
    {
        image.gameObject.SetActive(false);

    }
}
