using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Jetpack : MonoBehaviour
{
     bool levelOne;
    bool canDash = true;
    [SerializeField] float dashCD;
    [SerializeField] float dashDuration;
    [SerializeField] float dashDistance;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            levelOne=true; 
        }
        else
        {
            levelOne = false;
        }
    }
    private void Update()
    {
        if(!levelOne && canDash && Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(UseJetpack());
        }
    }
    IEnumerator UseJetpack()
    {
        canDash = false;
        Debug.Log("Dashing");

        Vector3 dashDirection = transform.forward;
        dashDirection.y = 0;
        Vector3 dashEndPosition = transform.position + dashDirection * dashDistance;

        float startTime = Time.time;
        while (Time.time - startTime < dashDuration)
        {
            float progress = (Time.time - startTime) / dashDuration;
            transform.position = Vector3.Lerp(transform.position, dashEndPosition, progress);
            yield return null;
        }

        transform.position = dashEndPosition;

        yield return new WaitForSeconds(dashCD);
        canDash = true;
    }

}
