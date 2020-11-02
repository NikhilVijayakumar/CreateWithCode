using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 5.0f;
    private Rigidbody enemyRB;  
    private SpawnManager manager;
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        manager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();       
    }

    private void isEnemyAlive()
    {
       if(transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

    private void MoveEnemy()
    {
        Vector3 moveTo = (manager.player.transform.position - transform.position).normalized;
        enemyRB.AddForce(moveTo * speed);
        isEnemyAlive();
    }
}
