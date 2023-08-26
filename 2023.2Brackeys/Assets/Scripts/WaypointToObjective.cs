using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointToObjective : MonoBehaviour
{
   /* [SerializeField] Transform player;
    [SerializeField] Transform targetObject1;
    [SerializeField] Transform targetObject2;
    [SerializeField] RectTransform arrowTransform;
    [SerializeField] ItemPickUp IPU;
    private void Update()
    {
        
        if (!IPU.itemPickedUp)
        {
            // Calculate direction from player to target object
            Vector3 directionToTarget = (targetObject1.position - player.position).normalized;

            // Calculate the rotation needed to point the arrow in that direction
            float angle = Mathf.Atan2(directionToTarget.x, directionToTarget.z) * Mathf.Rad2Deg;

            // Apply rotation to the arrow
            arrowTransform.rotation = Quaternion.Euler(0f, 0f, -angle);
        }
        else
        {
            // Calculate direction from player to target object
            Vector3 directionToTarget = (targetObject2.position - player.position).normalized;

            // Calculate the rotation needed to point the arrow in that direction
            float angle = Mathf.Atan2(directionToTarget.x, directionToTarget.z) * Mathf.Rad2Deg;

            // Apply rotation to the arrow
            arrowTransform.rotation = Quaternion.Euler(0f, 0f, -angle);
        }

    }*/
}
