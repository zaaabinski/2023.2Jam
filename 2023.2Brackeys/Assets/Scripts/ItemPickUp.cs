using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    bool canPickup = false;
    [SerializeField] GameObject pickupUI;
    private GameObject itemInRange;
    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Collectible"))
        {
            //show ui to pick up
            pickupUI.SetActive(true);
            canPickup = true;
            itemInRange = other.gameObject;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(canPickup&&Input.GetKeyDown("e"))
        {
            PickUp();
        }
    }
    void PickUp()
    {
        Debug.Log("PickedItem");
        Destroy(itemInRange,0.1f);
        canPickup = false;
        pickupUI.SetActive(false);
    }
}
