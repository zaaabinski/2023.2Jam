using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Oxygen : MonoBehaviour
{
    [SerializeField] AudioSource As;
    public int oxygenLeft;
    public int startOxygen;
    [SerializeField] Transform meterNeedle;
    public float minRotation = -60.0f; // Rotation value when oxygenLeft is 60
    public float maxRotation = 0.0f;   // Rotation value when oxygenLeft is 30
    public float rotationSpeed = 1.0f; // Rotation speed
    [SerializeField] Volume postProcessingVolume;
    [SerializeField] Vignette postVignette;
    //[SerializeField] Slider oxygenSlider;
    public float intesityToAdd;
    public float intesity;
    [SerializeField] ParticleSystem bubles;
    [SerializeField] int breathTime=0;
    int holdBreathTimer;
    //float helpDivider;
    [SerializeField] PauseAndButtons PAB;
    bool didntShow = true;
    [SerializeField] AudioSource IN;
    [SerializeField] AudioSource OUT;
    private void Start()
    {
        oxygenLeft = startOxygen;
        holdBreathTimer = Random.Range(1, 7);
        //oxygenSlider.maxValue = startOxygen;
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
        postVignette.intensity.Override(intesity);
        //oxygenSlider.value = oxygenLeft;
        if (oxygenLeft<=0)
        {
            NoOxygenLeft();
            PAB.GameLost();
        }
        if(breathTime>=holdBreathTimer)
        {
            StartCoroutine(BlowAir());
            breathTime = 0;
            holdBreathTimer = Random.Range(3, 8);
        }
        float rotation = -60.0f + (120.0f * (oxygenLeft / 60.0f));

        // Apply the rotation to the object
        meterNeedle.rotation = Quaternion.Euler(0.0f, 0.0f, -rotation);
        if(oxygenLeft>15)
        {
            didntShow = true;
        }
        // Rotate the object over time
        meterNeedle.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        if(oxygenLeft<15 && didntShow)
        {
            As.Play();
            didntShow= false;
        }
    }
    IEnumerator BlowAir()
    {
        IN.Play();
        yield return new WaitForSeconds(1.2f);
        OUT.Play();
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
