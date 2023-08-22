using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ItemPickUp IPU = other.GetComponent<ItemPickUp>();
            if(IPU.itemPickedUp)
            {
                Debug.LogWarning("Mission complete");
                Time.timeScale = 0f;
            }
        }
    }
}
