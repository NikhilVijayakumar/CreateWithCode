using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab; 
    private float spawnInterval = 1.5f;
    private bool isDogSpawn = true;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (isDogSpawn && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SpawnDog());
        }       
    }
    IEnumerator SpawnDog()
    {
        isDogSpawn = false;
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        yield return new WaitForSeconds(spawnInterval);
        isDogSpawn = true;
        yield return null;
    }
}
