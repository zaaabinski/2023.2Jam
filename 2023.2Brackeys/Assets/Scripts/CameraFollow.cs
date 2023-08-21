using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The player's transform

    public float heightOffset = 2f; // Adjust the camera's height offset
    public float smoothSpeed = 0.125f; // Adjust the camera's smoothness

    private Vector3 desiredPosition;

    private void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position for the camera
            desiredPosition = target.position + Vector3.up * heightOffset;

            // Smoothly move the camera to the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
    }
}
