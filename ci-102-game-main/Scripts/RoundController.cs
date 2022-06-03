using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    public GameObject basicEnemy;
    public GameObject uiObject;

    public float timeBetweenWaves;
    public float timeBeforeRoundStart;
    public float time;
    
    public bool isRoundGoing;
    public bool isIntermission;
    public bool isRoundStart;

    public int round;

    private void Start()
    {
        uiObject.SetActive(false);

        isRoundGoing = false;
        isIntermission = false;
        isRoundStart = true;

        time = Time.time + timeBeforeRoundStart;

        round = 1;
    }

    private void spawnEnemies()
    {
         StartCoroutine("ISpawnEnemies");
    }

    IEnumerator ISpawnEnemies()
    {
        for(int i = 0; i < round; i++)
        {
            GameObject newEnemy = Instantiate(basicEnemy, MapGenerator.startTile.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        Destroy(uiObject);
    }
    private void Update()
    {
        if(isRoundStart)
        {
            if(Time.time >= time)
            {
                isRoundStart = false;
                isRoundGoing = true;
                return;
            }
        }
        else if (isIntermission)
        {
            if (Time.time >= time)
            {
                isIntermission = false;
                isRoundGoing = true;
                uiObject.SetActive(true);
                StartCoroutine("Wait");
                //SpawnEnemies() //Need Spawn Enemies Function
                return;
            }
        }
        else if (isRoundGoing)
        {
            if(Enemies.enemies.Count > 0) //Check num enemies remaining 
            {
                
            }
            else
            {
                isIntermission = true;
                isRoundGoing = false;

                time = Time.time + timeBetweenWaves;
                round++;
                return;
            }
        }
    }
}
