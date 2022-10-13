using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FingerTutorial : MonoBehaviour
{
    [SerializeField] Image fingerImage;
    [SerializeField] Transform max;
    [SerializeField] Transform min;
    [SerializeField] float duration;
    [SerializeField] Sprite fingerPressed;
    [SerializeField] Sprite fingerNormal;

    bool pressed;
    bool end;
    float time;
    private void Start()
    {
       
        time = duration - 1f;
        fingerImage.sprite = fingerNormal;

    }
    void Update()
    {
        fingerImage.DOFade(1, 0.3f);
        time+=Time.deltaTime;
        if (time > duration&& !pressed&&!end)
        {
            if (fingerImage.sprite == fingerNormal)
            {
                fingerImage.sprite = fingerPressed;
            }
            fingerImage.rectTransform.DOMove(max.position, duration);
            pressed = true;
            time = 0;
               
        }
        if (time > duration && pressed&&!end)
        {
            if (fingerImage.sprite == fingerPressed)
            {
                fingerImage.sprite = fingerNormal;
            }
            if(time > duration + 0.5f)
            {
                fingerImage.rectTransform.DOMove(min.position, duration / 2);
                end = true;
            }
           
        }
        if (time > duration + duration/2+0.5f&&end)
        {
            time = 0;
            end=false;
            pressed = false;
        }
    }
  
    private void OnEnable()
    {
        StartCoroutine(UpdateKill());

    }
    private void OnDisable()
    {
        if(GameStats.Instance.VirtualLevel == 1)
        {
            FrogController.OnFroggoJump -= KillObject;

        }

    }
    void KillObject()
    {
        Destroy(gameObject);
    }
    IEnumerator UpdateKill()
    {
        yield return new WaitForEndOfFrame();
        if (GameStats.Instance.VirtualLevel > 1)
        {
            KillObject();
        }
        else
        {
            FrogController.OnFroggoJump += KillObject;

        }
    }
    
}
 