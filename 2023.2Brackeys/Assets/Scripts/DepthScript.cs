using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DepthScript : MonoBehaviour
{
   [SerializeField] Transform underwaterBase;
    [SerializeField] Transform player;
    [SerializeField] CameraFollow CF;
    public float distanceFromBase;
    [SerializeField] TextMeshProUGUI distanceTXT;
    float minCamOffest = 0.5f;
    float maxCamOffset = 2.5f;
    float camOffset;
    float fogDens;
    private void Start()
    {
        camOffset = CF.heightOffset;
    }
    private void FixedUpdate()
    {
        distanceFromBase = Mathf.Ceil(Mathf.Abs(player.transform.position.x - underwaterBase.transform.position.x) + Mathf.Abs(player.transform.position.z - underwaterBase.transform.position.z));
        distanceTXT.text = distanceFromBase.ToString() + " m";
        camOffset = 0.5f + distanceFromBase / 50f;
        camOffset = Mathf.Clamp(camOffset, minCamOffest, maxCamOffset);
        CF.heightOffset = camOffset;
        fogDens = 0.1f + distanceFromBase / 1000f;
        RenderSettings.fogDensity = fogDens;
    }

}
