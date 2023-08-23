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
        GameObject monster = Instantiate(monsterPref);

        monsterCount++;
        monster.transform.position = new Vector3(gameObject.transform.position.x + Random.Range(8,15.5f), 0.1f, gameObject.transform.position.z + Random.Range(-5, -8.5f));
        yield return new WaitForSeconds(2);
        canSpawn = true;
    }

}
