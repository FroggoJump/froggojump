using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXController : MonoBehaviour
{
    [SerializeField] ParticleSystem jump;
    [SerializeField] ParticleSystem dust;
    [SerializeField] ParticleSystem waterSplash;
    [SerializeField] Transform frogPos;
    [SerializeField] AudioSource aS;
    bool splashPlaying = false;
    bool isUnderWater;
    private void Update()
    {
        SplashActivate();
    }

    void DustActivate()
    {
        dust.Play();
    }

    void JumpActivate()
    {
        jump.gameObject.transform.position = new Vector3(frogPos.position.x, frogPos.position.y + 0.3f, frogPos.position.z);
        jump.Play();
        jump.gameObject.transform.parent = null;
    }

    void SplashActivate()
    {
        if (frogPos.position.y <= 0&&!waterSplash.isPlaying&& !isUnderWater)
        {
            isUnderWater = true;
            waterSplash.gameObject.transform.parent = null;
            waterSplash.gameObject.transform.position = new Vector3(frogPos.position.x, frogPos.position.y + 0.3f, frogPos.position.z);
            
            waterSplash.Play();
            aS.Play();
        }
        if (frogPos.position.y >= 0.2f)
        {
            isUnderWater = false;

        }
    }

    private void OnEnable()
    {
        FrogController.OnFroggoLand += DustActivate;
        FrogController.OnFroggoJump += JumpActivate;
    }

    private void OnDisable()
    {
        FrogController.OnFroggoLand -= DustActivate;
        FrogController.OnFroggoJump -= JumpActivate;
    }
}
