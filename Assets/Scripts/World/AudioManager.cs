using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    int firstplay;
    [SerializeField] Slider backgroundSlider, soundEffectsSlider;
    float backgroundFloat, soundEffectsFloat;
    [SerializeField] Image musicMuted;
    [SerializeField] Image sfxMuted;
    // --------------------------------------------
    [SerializeField] AudioSource audiosource, MusicAudioSource;
    [SerializeField] AudioClip[] clips;

    private void Awake()
    {
        firstplay = PlayerPrefs.GetInt("firstplay");
        if (firstplay == 0)
        {
            backgroundFloat = 0.25f;
            soundEffectsFloat = 0.5f;
            backgroundSlider.value = backgroundFloat;
            soundEffectsSlider.value = soundEffectsFloat;
            PlayerPrefs.SetFloat("backgroundpref", backgroundFloat);
            PlayerPrefs.SetFloat("soundEffectpref", soundEffectsFloat);
            PlayerPrefs.SetInt("firstplay", -1);
        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat("backgroundpref");
            backgroundSlider.value = backgroundFloat;

            soundEffectsFloat = PlayerPrefs.GetFloat("soundEffectpref");
            soundEffectsSlider.value = soundEffectsFloat;

            CheckMute();
        }
    }

    public void SaveSoundsSettings()
    {
        PlayerPrefs.SetFloat("backgroundpref", backgroundFloat);
        PlayerPrefs.SetFloat("soundEffectpref", soundEffectsFloat);
    }

    public void UpdateSound()
    {
        MusicAudioSource.volume = backgroundSlider.value; 
        audiosource.volume = soundEffectsSlider.value;

        backgroundFloat = backgroundSlider.value;
        soundEffectsFloat = soundEffectsSlider.value;

        CheckMute();        
    }

    public void CheckMute()
    {
        if (backgroundFloat == 0) musicMuted.enabled = true;
        else musicMuted.enabled = false;

        if (soundEffectsFloat == 0) sfxMuted.enabled = true;
        else sfxMuted.enabled = false;
    }

    private void OnEnable()
    {
        FrogController.OnFroggoJump += FrogJump;
        FrogController.OnFroggoLand += Land;
        FlyPoints.OnFlySquashed += squashedFly;
    }
    private void OnDisable()
    {
        FrogController.OnFroggoJump -= FrogJump;
        FrogController.OnFroggoLand -= Land;
        FlyPoints.OnFlySquashed -= squashedFly;

    }
    void FrogJump()
    {
        audiosource.clip= clips[0];
        audiosource.Play();
    }

    void Land()
    {
        audiosource.clip= clips[1];
        audiosource.Play();
    }

    void squashedFly()
    {
        audiosource.clip = clips[3];
        audiosource.Play();
    }

   public void Button()
   {
        audiosource.clip = clips[2];
        audiosource.Play();
   }
    public void ButtonShop()
    {
        audiosource.clip = clips[7];
        audiosource.Play();
    }

    public void Buy()
    {
        audiosource.clip = clips[5];
        audiosource.Play();
    }

    public void NoMoney()
    {
        audiosource.clip = clips[4];
        audiosource.Play();
    }
}
