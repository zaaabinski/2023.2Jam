using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sanity : MonoBehaviour
{
    int monsterCount;
    [SerializeField] Oxygen OX;
    [SerializeField] DepthScript DP;
    [SerializeField] GameObject monsterPref1;
    [SerializeField] GameObject monsterPref2;
    //sanity calculator
    public float sanity = 100f;
    int oxDiff;
    bool canSpawn = true;
    private void Update()
    {
        oxDiff = OX.startOxygen - OX.oxygenLeft;
        sanity = 100 - oxDiff - DP.distanceFromBase;
        if (monsterCount <= 4 && sanity < 70 && canSpawn)
        {
            StartCoroutine(SpawnMonster());
        }
    }

    IEnumerator SpawnMonster()
    {
        canSpawn = false;
        GameObject monsterPref;
        if (Random.Range(1,3)==1)
        {
            monsterPref = monsterPref1;
        }
        else
        {
            monsterPref = monsterPref2;
        }
         GameObject monster = Instantiate(monsterPref);
        monsterCount++;
        Vector2 randomCirclePoint = Random.insideUnitCircle.normalized * Random.Range(10, 15);
        Vector3 randomPosition = gameObject.transform.position + new Vector3(randomCirclePoint.x, 0.2f, randomCirclePoint.y);
        //transform.position = randomPosition;
        monster.transform.position = randomPosition;
        yield return new WaitForSeconds(2);
        canSpawn = true;
    }

}
