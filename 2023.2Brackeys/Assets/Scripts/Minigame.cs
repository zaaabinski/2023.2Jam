using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class Minigame : MonoBehaviour
{
    [SerializeField] AudioSource As;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject playerUI;
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
        playerUI.SetActive(false);
        gameUI.SetActive(true);
        redB = false; greenB = false; blueB = false; yellowB = false;
        red = 0; green = 0; blue = 0; yellow = 0;
        Time.timeScale = 0f;
        PlaceWires(placeHoldersL, wiresL);
        PlaceWires(placeHoldersR, wiresR);
        for (int i = 0; i < 4; i++)
        {
            wire[i].transform.localPosition = new Vector3(150, 0, 0);
            Image im = wire[i].GetComponent<Image>();
            im.rectTransform.sizeDelta = new Vector2(75, 75);
            im.rectTransform.rotation = Quaternion.Euler(0, 0, 0);
        }
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

    private void StretchImage(RectTransform imageRectTransform, Transform startPoint, Transform endPoint)
    {
        // Calculate the distance between the points
        float distance = Vector2.Distance(startPoint.position, endPoint.position);

        // Set the size of the image RectTransform along the x-axis
        imageRectTransform.sizeDelta = new Vector2(distance*2.1f, imageRectTransform.sizeDelta.y);

        // Calculate the center position between the points
        Vector2 centerPosition = (startPoint.position + endPoint.position) / 2f;

        // Set the position of the image RectTransform
        imageRectTransform.position = centerPosition;

        // Calculate the angle between the points
        Vector2 direction = endPoint.position - startPoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Set the rotation of the image RectTransform
        imageRectTransform.rotation = Quaternion.Euler(0f, 0f, angle);
    }




    IEnumerator Win()
    {
        Debug.Log("Win");
        minigameWon = true;
        yield return new WaitForSecondsRealtime(0.5f);
        As.Play();
        playerUI.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
