using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    [SerializeField] GameObject gameUI;
    [SerializeField] List<Transform> placeHoldersL;
    [SerializeField] List<Transform> placeHoldersR;
    [SerializeField] List<GameObject> wiresL;
    [SerializeField] List<GameObject> wiresR;
    [SerializeField] List<int> takenPlaces;
    int place;
    int red = 0, green = 0, blue = 0, yellow = 0;
    int totalConnceted = 0;
    public bool minigameWon = false;
    bool redB=false, greenB=false, blueB=false, yellowB=false;
    [SerializeField] List<RectTransform> wire;
    [SerializeField] List<Transform> startConnect;
    [SerializeField] List<Transform> endConnect;
    [SerializeField] List<GameObject> wiresToHide;

    public bool Game()
    {
        totalConnceted = 0;
        minigameWon = false;

        gameUI.SetActive(true);
        redB = false; greenB = false; blueB = false; yellowB = false;
        red = 0; green = 0; blue = 0; yellow = 0;
        Time.timeScale = 0f;
        PlaceWires(placeHoldersL, wiresL);
        PlaceWires(placeHoldersR, wiresR);
        return true;
    }
    private void Update()
    {
        if(red==2 && !redB)
        {
            Debug.Log("Red connected");
            totalConnceted++;
            redB = true;
            StretchImage(wire[0], startConnect[0], endConnect[0]);
            wiresToHide[0].SetActive(false);
        }
        if (green == 2 && !greenB)
        {
            Debug.Log("green connected");
            totalConnceted++;
            greenB = true;
            StretchImage(wire[1], startConnect[1], endConnect[1]);
            wiresToHide[1].SetActive(false);
        }
        if (blue == 2 && !blueB)
        {
            Debug.Log("blue connected");
            totalConnceted++;
            blueB = true;
            StretchImage(wire[2], startConnect[2], endConnect[2]);
            wiresToHide[2].SetActive(false);
        }
        if (yellow == 2 && !yellowB)
        {
            Debug.Log("yellow connected");
            totalConnceted++;
            yellowB = true;
            StretchImage(wire[3], startConnect[3], endConnect[3]);
            wiresToHide[3].SetActive(false);
        }
        if(totalConnceted==4 && !minigameWon)
        {
            StartCoroutine(Win());
        }
    }

    private void PlaceWires(List<Transform> placeHolders, List<GameObject> objectsToDistribute)
    {
        List<int> availableIndices = new List<int>();
        for (int i = 0; i < placeHolders.Count; i++)
        {
            availableIndices.Add(i);
        }

        foreach (GameObject obj in objectsToDistribute)
        {
            int randomIndex = Random.Range(0, availableIndices.Count);
            int selectedIndex = availableIndices[randomIndex];

            obj.transform.position = placeHolders[selectedIndex].position;
            availableIndices.RemoveAt(randomIndex);
        }
    }

    public void RedButton()
    {
        red+=1;
        yellow = 0;
        green = 0;
        blue= 0;
        
    }
    public void BlueButton()
    {
        red = 0;
        yellow = 0;
        green = 0;
        blue += 1;
    }
    public void GreenButton()
    {
        red =0;
        yellow = 0;
        green += 1;
        blue = 0;
    }
    public void YellowButton()
    {
        red =0;
        yellow += 1;
        green = 0;
        blue = 0;
    }

    private void StretchImage(RectTransform imageRectTransform,Transform startPoint, Transform endPoint)
    {
        // Calculate the distance between the points
        float distance = Vector2.Distance(startPoint.transform.position, endPoint.transform.position);

        // Set the size of the image RectTransform
        imageRectTransform.sizeDelta = new Vector2(distance, imageRectTransform.sizeDelta.y);

        // Calculate the angle between the points
        float angle = Mathf.Atan2(endPoint.transform.position.y - startPoint.transform.position.y, endPoint.transform.position.x - startPoint.transform.position.x) * Mathf.Rad2Deg;

        // Set the rotation of the image RectTransform
        imageRectTransform.rotation = Quaternion.Euler(0f, 0f, angle);

        // Set the position of the image RectTransform
        imageRectTransform.position = (startPoint.transform.position + endPoint.transform.position) / 2f;
    }

    IEnumerator Win()
    {
        Debug.Log("Win");
        minigameWon = true;
        yield return new WaitForSecondsRealtime(0.5f);
        gameUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
