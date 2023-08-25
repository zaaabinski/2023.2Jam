using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] GameObject minigameUI;
    Minigame MG;
    bool inMinigame=false;
    private void Start()
    {
        MG = minigameUI.GetComponent<Minigame>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //start minigame
            inMinigame= true;
            MG.Game();
        }
    }
 
    private void Update()
    {
        if (MG.minigameWon && inMinigame)
        {
            //minigame done
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -2, gameObject.transform.position.y);
            Destroy(gameObject);
        }
    }
}
