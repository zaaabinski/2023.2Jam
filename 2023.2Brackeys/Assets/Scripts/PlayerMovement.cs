using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 10f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rb.freezeRotation = true;
    }

    private void Update()
    {
        // Get movement input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calculate movement direction
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (movementDirection != Vector3.zero)
        {
            // Calculate rotation towards movement direction
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        // Get movement input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calculate movement direction
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // If there's no movement input, stop the player's movement
        if (movementDirection == Vector3.zero)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            // Calculate movement velocity
            Vector3 movementVelocity = movementDirection * movementSpeed;
            rb.velocity = new Vector3(movementVelocity.x, rb.velocity.y, movementVelocity.z);
        }
    }
    //animate 
    /*Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
    if (direction == Vector3.zero)
    {
        anim.SetFloat("Speed", 0);
    }
    else
    {
        anim.SetFloat("Speed", 1);
    }*/
}
