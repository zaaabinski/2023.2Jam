using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMonsters : MonoBehaviour
{
    float timeNotVisible = 0;
    Animator anim;
    private void Start()
    {
<<<<<<< Updated upstream
    anim = gameObject.GetComponentInChildren<Animator>();
=======
        anim= gameObject.GetComponentInChildren<Animator>();
>>>>>>> Stashed changes
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
        Renderer mRenerer = gameObject.GetComponent<Renderer>();
        
        if (!mRenerer.isVisible)
        {
            timeNotVisible += Time.deltaTime;
            if (timeNotVisible > 4)
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
