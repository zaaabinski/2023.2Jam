using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSwimming : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(FindNewSpot());
    }

    private IEnumerator FindNewSpot()
    {
        while (true)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = GetRandomPosition();
            float journeyLength = Vector3.Distance(startPos, endPos);

            float startTime = Time.time;
            float stayTime = journeyLength/2;
            float duration = stayTime; // Adjust the duration as needed

            while (Time.time - startTime < duration)
            {
                float distanceCovered = (Time.time - startTime) * journeyLength / duration;
                float fractionOfJourney = distanceCovered / journeyLength;

                transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);

                Vector3 direction = (endPos - startPos).normalized;
                float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5);

                yield return null;
            }

            // Ensure the object reaches the final position exactly
            transform.position = endPos;
          
            
        }
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-10f, 10f);
        float y = Random.Range(0f, 5f);
        float z = Random.Range(-10f, 10f);
        return new Vector3(x, y, z);
    }
}
