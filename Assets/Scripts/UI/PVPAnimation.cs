using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class PVPAnimation : MonoBehaviour
{
    public Image green;
    public Image red;
    public Image middle;
    [SerializeField] RectTransform green_pos;
    [SerializeField] RectTransform red_pos;
    public bool end;
   
    //private void Update()
    //{
    //    Time.timeScale = 1;
    //    if (end)
    //    {
    //        DOTween.Sequence(middle.DOFade(0, 0.5f)).Join(green.gameObject.transform.DOMove(green_pos.position, 1f)).Join(red.gameObject.transform.DOMove(red_pos.position, 1f));
    //        end = false;
    //    }
    //}
    public void Animate()
    {
        DOTween.Sequence(middle.DOFade(1, 0.5f)).Join(green.gameObject.transform.DOMove(green_pos.position,1f)).Join(red.gameObject.transform.DOMove(red_pos.position, 1f));
        
    }
}
