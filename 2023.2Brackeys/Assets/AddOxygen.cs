using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddOxygen : MonoBehaviour
{
    [SerializeField] int howMuchToAdd;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Oxygen ox = other.gameObject.GetComponent<Oxygen>();
            if (ox.oxygenLeft>45)
            {
                ox.oxygenLeft = ox.startOxygen;
            }
            else
            {
                ox.oxygenLeft += howMuchToAdd;
            }
            Destroy(gameObject);
        }
    }
}
