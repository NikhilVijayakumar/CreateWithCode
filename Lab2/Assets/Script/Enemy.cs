using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody enemyRB;
    private float bottomBound = 17.2f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
        isEnemyAlive();
       
    }

    private void isEnemyAlive()
    {
        if (transform.position.z > bottomBound)
        {
            Destroy(gameObject);
        }
    }

    private void MoveEnemy()
    {
        enemyRB.AddForce(Vector3.forward * speed,ForceMode.Acceleration);
    }
}
