using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DepthScript : MonoBehaviour
{
   [SerializeField] Transform underwaterBase;
    [SerializeField] Transform player;
    public float distanceFromBase;
    [SerializeField] TextMeshProUGUI distanceTXT;
    private void FixedUpdate()
    {
        distanceFromBase = Mathf.Ceil(Mathf.Abs(player.transform.position.x - underwaterBase.transform.position.x) + Mathf.Abs(player.transform.position.z - underwaterBase.transform.position.z));
        distanceTXT.text = distanceFromBase.ToString() + " m";
    }

}
