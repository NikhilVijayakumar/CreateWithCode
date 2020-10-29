using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalList;
    private int xRange = 18;
    private int zpos = 19;
    private float startDelay = 2f;
    private float interval = 1.5f;

    private void Start()
    {
        InvokeRepeating("SpawnAnimal",startDelay,interval); 
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void SpawnAnimal()
    {
        GameObject animal = GetRandromAnimal();
        Instantiate(animal, GetRandromPosition(), animal.transform.rotation);
    }

    private GameObject GetRandromAnimal()
    {

        return animalList[Random.Range(0, animalList.Length)];
    }

    private Vector3 GetRandromPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange),0,zpos);
    }
}
