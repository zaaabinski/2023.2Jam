using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMonsters : MonoBehaviour
{
    float timeNotVisible = 0;
    Animator anim;
    private void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            anim.SetTrigger("Bite");
            Debug.Log("Game over");
        }
    }
    private void Update()
    {
        Renderer mRenerer = gameObject.GetComponentInChildren<Renderer>();
        
        if (!mRenerer.isVisible)
        {
            timeNotVisible += Time.deltaTime;
            if (timeNotVisible > 7.5f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            timeNotVisible = 0;
        }
    }
}
