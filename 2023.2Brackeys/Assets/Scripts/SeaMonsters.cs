using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMonsters : MonoBehaviour
{
    //float timeNotVisible = 0;
    Animator anim;
    [SerializeField] PauseAndButtons PAB;
    [SerializeField] AudioSource AS;
    private void Start()
    {
        PAB = GameObject.Find("Canvas").GetComponent<PauseAndButtons>();    
        anim = gameObject.GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(Bite());
        }
    }
    private void Update()
    {
      /*  Renderer mRenerer = gameObject.GetComponentInChildren<Renderer>();
        
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
        }*/
    }
    IEnumerator Bite()
    {
        anim.SetTrigger("Bite");
        Debug.Log("Game over");
        AS.Play();
        yield return new WaitForSeconds(0.5f);
        PAB.GameLost();
    }
}
