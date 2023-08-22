using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    bool canPickup = false;
    [SerializeField] GameObject pickupUI;
    private GameObject itemInRange;
    public bool itemPickedUp;
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
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            pickupUI.SetActive(false);
            canPickup = false;
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
        itemPickedUp = true;
        canPickup = false;
        pickupUI.SetActive(false);
    }
}
