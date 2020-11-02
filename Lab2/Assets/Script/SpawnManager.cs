using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyList;
    public GameObject powerups;
    private float startTime = 1f;
    private float enemyWaveTime = 3.2f;
    private float powerupTime = 5.5f;

    private float zEnemy = -9.3f;
    private float zPowerups = 3.3f;
    private float xSpawn = 19f;
    private float ySpawn = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateRandomEnemy", startTime, enemyWaveTime);
        InvokeRepeating("GenerateRandomPowerups", startTime, powerupTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateRandomEnemy()
    {
        int index = Random.Range(0, enemyList.Length);
        GameObject enemy = enemyList[index];
        float xEnemy = Random.Range(-xSpawn, xSpawn);
        Vector3 postion = new Vector3(xEnemy, ySpawn, zEnemy);
        Instantiate(enemy, postion, enemy.transform.rotation);
    }

    private void GenerateRandomPowerups()
    {
        float xPowerup = Random.Range(-xSpawn, xSpawn);
        float zSpawn = Random.Range(-zPowerups, zPowerups);
        Vector3 postion = new Vector3(xPowerup, ySpawn, zSpawn);
        Instantiate(powerups, postion, powerups.transform.rotation);
    }
}
