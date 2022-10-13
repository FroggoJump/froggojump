using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;

public class StageChager : MonoBehaviour
{
    [SerializeField] int index;
    Transform m_transform;
    [SerializeField] Transform m_target;
    public static Action Onchanged;
    private void Start()
    {
        m_transform = transform.parent;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            m_transform.parent = null;
            collision.gameObject.transform.parent = transform.parent;
            Restart();
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        FrogCentral.frog.gameObject.GetComponentInParent<WorldMovement>().enabled = false;
        FrogCentral.frog.gameObject.GetComponentInParent<Rigidbody>().velocity= Vector3.zero;
        FrogCentral.frog.gameObject.GetComponentInParent<Rigidbody>().useGravity = false;


        Invoke("DisableFrog", 0.2f);
        m_transform.DOMove(m_target.position, 7f);
        Invoke("ChangeScene", 4f);

    }

    void DisableFrog()
    {
        Destroy(FrogCentral.frog.gameObject.GetComponentInParent<FreePath>());
        Destroy(FrogCentral.frog.gameObject.GetComponentInParent<FrogController>());

    }
    void ChangeScene()
    {
        ScreenManager.FadeScreen();
        Invoke("Change", 0.35f);
    }
    void Change()
    {
        Onchanged?.Invoke();
        PlayerPrefs.SetInt("statsflies", FlyManager.count);
        PlayerPrefs.SetFloat("statsjumps", PlayerStats.JumpAmount);
        PlayerPrefs.SetFloat("statspoints", Points.distanceUnit);
        PlayerPrefs.SetInt("savedpoints", Points.distanceUnit);
        PlayerPrefs.SetInt("savedflies", FlyManager.count);
        PlayerPrefs.SetInt("savedRings", Frog.currentShield);
        if (Frog.currentShield>0)
        {
            PlayerPrefsExtra.SetBool("salvavidasguardado", true);
            
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+ index);

    }

}
