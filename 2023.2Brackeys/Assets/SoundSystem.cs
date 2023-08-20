using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SoundSystem : MonoBehaviour
{
    public AudioMixer mainMixer;

    public Slider mainSlider;
    public Slider musicSlider;
    public Slider effectsSlider;

    float value1, value2, value3;
    private void Start()
    {
        StartVolumeMain();
        StartVolumeMusic();
        StartVolumeSfx();
    }

    public void StartVolumeMain()
    {
        GetFloat1("mainMixerVolume");
        ChangeVolumeMain(value1);
    }
    public void StartVolumeMusic()
    {
        GetFloat2("musicMixerVolume");
        ChangeVolumeMusic(value2);
    }
    public void StartVolumeSfx()
    {
        GetFloat3("sfxMixerVolume");
        ChangeVolumeSFX(value3);
    }

    public void ChangeVolumeMain(float soundLevel)
    {
        SetFloat("mainMixerVolume", soundLevel);
        mainMixer.SetFloat("MainVol", Mathf.Log10(soundLevel) * 20);
    }
    public void ChangeVolumeMusic(float soundLevel)
    {
        SetFloat("musicMixerVolume", soundLevel);
        mainMixer.SetFloat("MusicVol", Mathf.Log10(soundLevel) * 20);
    }
    public void ChangeVolumeSFX(float soundLevel)
    {
        SetFloat("sfxMixerVolume", soundLevel);
        mainMixer.SetFloat("SFXVol", Mathf.Log10(soundLevel) * 20);
    }


    void SetFloat(string sensName, float value)
    {
        PlayerPrefs.SetFloat(sensName, value);
    }
    void GetFloat1(string valueName)
    {
        if (PlayerPrefs.HasKey(valueName))
        {
            value1 = PlayerPrefs.GetFloat(valueName);
            mainSlider.value = PlayerPrefs.GetFloat(valueName);
        }
        else
        {
            mainSlider.value = 1;
        }
    }
    void GetFloat2(string valueName)
    {
        if (PlayerPrefs.HasKey(valueName))
        {
            value2 = PlayerPrefs.GetFloat(valueName);
            musicSlider.value = PlayerPrefs.GetFloat(valueName);
        }
        else
        {
            musicSlider.value = 1;
        }
    }
    void GetFloat3(string valueName)
    {
        if (PlayerPrefs.HasKey(valueName))
        {
            value3 = PlayerPrefs.GetFloat(valueName);
            effectsSlider.value = PlayerPrefs.GetFloat(valueName);
        }
        else
        {
            effectsSlider.value = 1;
        }
    }

}
