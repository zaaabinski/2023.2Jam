using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bolts : MonoBehaviour
{
    public int boltNumber;
    int boltCapacity = 20;
    [SerializeField] MissionEnd ME;
    [SerializeField] GameObject showMessage;
    [SerializeField] TextMeshProUGUI boltText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bolt"))
        {
            if (boltNumber < boltCapacity)
            {
                boltNumber += 5;
                Destroy(other.gameObject);
            }
            else
            {
                Debug.Log("Im carring too much");
                showMessage.SetActive(true);  
            }
        }
        if (other.gameObject.CompareTag("Base"))
        {
            ME = other.GetComponent<MissionEnd>();
            ME.boltsStored += boltNumber;
            boltNumber= 0;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bolt"))
        {
            showMessage.SetActive(false);
        }
    }
    private void Update()
    {
        boltText.text = boltNumber.ToString() + "/20";
    }
}
