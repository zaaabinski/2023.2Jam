using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionEnd : MonoBehaviour
{
    public int boltsStored;
    [SerializeField] PauseAndButtons PAB;

    private void Update()
    {
        if(boltsStored>=100)
        {
            Debug.Log("Game won");
            PAB.GameWon();

        }
    }
}
