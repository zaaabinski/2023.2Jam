using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointToObjective : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform targetObject;
    [SerializeField] RectTransform arrowTransform;
    private void Update()
    {
        if(targetObject.gameObject.activeInHierarchy)
        {
        // Calculate direction from player to target object
        Vector3 directionToTarget = (targetObject.position - player.position).normalized;

        // Calculate the rotation needed to point the arrow in that direction
        float angle = Mathf.Atan2(directionToTarget.x, directionToTarget.z) * Mathf.Rad2Deg;

        // Apply rotation to the arrow
        arrowTransform.rotation = Quaternion.Euler(0f, 0f, -angle);
        }
    }
}
