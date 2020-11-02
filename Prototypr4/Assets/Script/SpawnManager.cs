using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemy;
    public GameObject powerup;
    public GameObject playerPrefab;
    private float enemySpawnRange = 10;
    private float powerUpSpawnRange = 6;
    public GameObject player;
    private int enemyWave = 1;
    private int enemyCount = 0;
    public int playerCount = 1;


    void Start()
    {
        SpawnAll();
    }

  
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;        
        if (enemyCount == 0 && player.transform.position.y > - 2)
        {
            enemyWave++;
            SpawnPowertUp();
            SpawnEnemyWave();

        }
    }

    private void SpawnAll()
    {
        SpawnPlayer();
        SpawnPowertUp();
        SpawnEnemyWave();

       
    }

    private void SpawnEnemyWave()
    {
        for(int i=0;i< enemyWave; i++)
        {
            Instantiate(enemy, GetSpawnPostion(ObjectType.Enemy), enemy.transform.rotation);
        }
       
    }

    private void SpawnPowertUp()
    {
        Instantiate(powerup, GetSpawnPostion(ObjectType.Powerups), powerup.transform.rotation);
    }

    private void SpawnPlayer()
    {
        player = Instantiate(playerPrefab, GetSpawnPostion(ObjectType.Player), playerPrefab.transform.rotation);
    }

    private Vector3 GetSpawnPostion(ObjectType type)
    {
        switch ((int)type)
        {
            case 0:
                   return new Vector3(0, 0, 0);
            case 1:
                float spawnx = Random.Range(-enemySpawnRange, enemySpawnRange);
                float spawnz = Random.Range(-enemySpawnRange, enemySpawnRange);
                return new Vector3(spawnx, 0, spawnz);
            case 2:
                 spawnx = Random.Range(-powerUpSpawnRange, powerUpSpawnRange);
                 spawnz = Random.Range(-powerUpSpawnRange, powerUpSpawnRange);
                return new Vector3(spawnx, 0, spawnz);
        }

        return new Vector3(0, 0, 0);
    }
}

public enum ObjectType
{
    Player,
    Enemy,
    Powerups
}
