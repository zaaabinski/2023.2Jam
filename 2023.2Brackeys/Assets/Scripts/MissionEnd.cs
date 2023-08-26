using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionEnd : MonoBehaviour
{
    public int boltsStored;
    [SerializeField] PauseAndButtons PAB;
    [SerializeField] GameObject boltTextObj;
    private TextMeshPro boltText;
    private void Start()
    {
        boltText = boltTextObj.GetComponent<TextMeshPro>();
    }
    private void Update()
    {
        if(boltsStored>=100)
        {
            Debug.Log("Game won");
            PAB.GameWon();

        }
        boltText.text = boltsStored.ToString() + "/100";
    }
}
