using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    private Vector3 spawnPostion = new Vector3(25,0,0);
    private float startDelay = 1f;
    private float interval = 2f;
    private PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle",startDelay,interval);
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (!controller.gameover)
        {
            Instantiate(obstacle, spawnPostion, obstacle.transform.rotation);
        }
           
    }
}
