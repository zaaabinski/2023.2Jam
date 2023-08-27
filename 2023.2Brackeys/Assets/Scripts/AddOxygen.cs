using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddOxygen : MonoBehaviour
{
    [SerializeField] int howMuchToAdd;
    [SerializeField] Oxygen OX;
    [SerializeField] AudioSource AS;
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
            AS.Play();
            ox.intesity -= ox.intesityToAdd * 15;
            StartCoroutine(HideAndShow());
        }
    }
    IEnumerator HideAndShow()
    {
        transform.position = new Vector3(transform.position.x, -10f,transform.position.z);
        yield return new WaitForSeconds(12);
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
}
