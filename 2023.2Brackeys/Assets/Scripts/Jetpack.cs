using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jetpack : MonoBehaviour
{
    bool levelOne;
    bool canDash = true;
    [SerializeField] float dashCD;
    [SerializeField] float dashForce;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            levelOne = true;
        }
        else
        {
            levelOne = false;
        }
    }

    private void Update()
    {
        if (!levelOne && canDash && Input.GetKeyDown(KeyCode.Space)) // Use GetKeyDown to trigger the dash once per press
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

        rb.AddForce(dashDirection.normalized * dashForce, ForceMode.VelocityChange);

        yield return new WaitForSeconds(dashCD);
        canDash = true;
    }
}
