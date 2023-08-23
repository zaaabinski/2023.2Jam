using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Oxygen : MonoBehaviour
{
    public int oxygenLeft;
    [SerializeField] Volume postProcessingVolume;
    [SerializeField] Vignette postVignette;
    [SerializeField] Slider oxygenSlider;
    [SerializeField] float intesityToAdd;
    float intesity;
    [SerializeField] ParticleSystem bubles;
    [SerializeField] int breathTime=0;
    int holdBreathTimer;
    //float helpDivider;
    private void Start()
    {
        holdBreathTimer = Random.Range(1, 7);
        oxygenSlider.maxValue = oxygenLeft;
        intesity = 0.3f;
        InvokeRepeating("DepleteOxygen", 1f, 1f);
         
        //getting vignette
        if (postProcessingVolume == null)
        {
            Debug.LogError("Post Processing Volume is not assigned!");
            return;
        }
        // Get the Vignette effect from the volume
        postProcessingVolume.profile.TryGet(out postVignette);
        postVignette.intensity.Override(intesity);
    }
    private void Update()
    {
        oxygenSlider.value = oxygenLeft;
        if(oxygenLeft<=0)
        {
            NoOxygenLeft();
        }
        if(breathTime>=holdBreathTimer)
        {
            BlowAir();
            breathTime = 0;
            holdBreathTimer = Random.Range(1, 7);
        }
    }
    void BlowAir()
    {
        bubles.Play();
    }
    void DepleteOxygen()
    {
        oxygenLeft--;
        intesity += intesityToAdd;
        postVignette.intensity.Override(intesity);
        breathTime++;
    }
    void NoOxygenLeft()
    {
        Time.timeScale = 0f;
        Debug.Log("Game lost");
    }
}
