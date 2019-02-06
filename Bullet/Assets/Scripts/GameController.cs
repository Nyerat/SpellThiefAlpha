using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject basic1;
    public Vector3 spawnValues;
    public Vector3 spawnBase;


    private void Start()
    {
        spawnBase = spawnValues;
        StartCoroutine(SpawnWaves());
        SpawnWaves();
    }

    //Bring in waves
    IEnumerator SpawnWaves()
    {
        
        Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
        yield return new WaitForSeconds(2f);
        SpawnEnemy(basic1, spawnValues, spawnPosition, 1, 0);
        SpawnEnemy(basic1, spawnValues, spawnPosition, -1, 0);
        yield return new WaitForSeconds(4f);

        for (float i = 0; i < 2.5; i = i + 0.5f)
        {
            yield return new WaitForSeconds(0.8f);
            SpawnEnemy(basic1, spawnValues, spawnPosition, i - 1, 0);
        }


    }

    void SpawnEnemy(GameObject enemy, Vector3 SpawnValues, Vector3 SpawnPosition, float yOffset, float xOffset)
    {
        spawnValues.y += yOffset;
        spawnValues.x += xOffset;
        SpawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
        Instantiate(enemy, SpawnPosition, transform.rotation);
        spawnValues = spawnBase;
    }



}
