using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sanity : MonoBehaviour
{
    int monsterCount;
    [SerializeField] Oxygen OX;
    [SerializeField] DepthScript DP;
    [SerializeField] GameObject monsterPref;
    //sanity calculator
    public float sanity = 100f;
    int oxDiff;
    bool canSpawn = true;
    bool rolledForSpawn=false;
    bool canRoll=true;
    private void Update()
    {
        oxDiff = OX.startOxygen - OX.oxygenLeft;
        sanity = 120 - oxDiff*2;// - DP.distanceFromBase;
        if (monsterCount <= 4 && rolledForSpawn && canSpawn)
        {
            StartCoroutine(SpawnMonster());
        }
        if(canRoll)
        {
            StartCoroutine(RollForSpawn());
        }
    }
    IEnumerator RollForSpawn()
    {
        canRoll = false;
        Debug.Log("ROlling");
        if(Random.Range(1,120)>sanity)
        {
            rolledForSpawn= true;
        }
        else
        {
            rolledForSpawn = false;
        }
        yield return new WaitForSeconds(2);
        canRoll= true; 
    }
    IEnumerator SpawnMonster()
    {
        canSpawn = false;
        GameObject monster = Instantiate(monsterPref);

        monsterCount++;
        Vector2 randomCirclePoint = Random.insideUnitCircle.normalized * Random.Range(10, 12);
        Vector3 randomPosition = gameObject.transform.position + new Vector3(randomCirclePoint.x, 0.2f, randomCirclePoint.y);
        //transform.position = randomPosition;
        monster.transform.position = randomPosition;
        yield return new WaitForSeconds(2);
        canSpawn = true;
    }

}
