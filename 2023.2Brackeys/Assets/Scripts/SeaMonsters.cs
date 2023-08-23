using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMonsters : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Game over");
        }
    }
}
