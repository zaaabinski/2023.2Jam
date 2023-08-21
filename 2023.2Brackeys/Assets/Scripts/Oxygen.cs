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
    //float helpDivider;
    private void Start()
    {
        oxygenSlider.maxValue = oxygenLeft;
        /*helpDivider = oxygenLeft / 5f;
        intesityToAdd = oxygenLeft / 1000f /helpDivider;*/
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
    }
    void DepleteOxygen()
    {
        oxygenLeft--;
        intesity += intesityToAdd;
        postVignette.intensity.Override(intesity);
    }
    void NoOxygenLeft()
    {
        Time.timeScale = 0f;
        Debug.Log("Game lost");
    }
}
