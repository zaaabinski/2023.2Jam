using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] Animator anim;
    private Rigidbody rb;

    private void Start()
    {
        //Time.timeScale = 1f;
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        // Get movement input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calculate movement direction
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // If there's no movement input, stop the player's movement
       /* if (movementDirection == Vector3.zero)
        {
            rb.velocity = Vector3.zero;
        }*/
        
            // Calculate movement velocity
            Vector3 movementVelocity = movementDirection * movementSpeed;
            rb.velocity = new Vector3(movementVelocity.x, rb.velocity.y, movementVelocity.z);
        if (movementDirection != Vector3.zero)
        {
            // Calculate rotation towards movement direction
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        //animate 
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        if (direction == Vector3.zero)
        {
            anim.SetFloat("Speed", 0);
        }
        else
        {
            anim.SetFloat("Speed", 1);
        }
    }
   
}
