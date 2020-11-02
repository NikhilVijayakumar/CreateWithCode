using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5;
    private float powerUpSpeed = 15;
    private float powerUpTime = 7;
    private GameObject focalPoint;
    private Rigidbody playerRB;
    public GameObject powerUpIndicator;
    private GameObject indicator;
    private bool hasPowerup = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        playerRB.AddForce(focalPoint.transform.forward * speed * vertical,ForceMode.Acceleration);
        if (hasPowerup)
        {
            indicator.transform.position = transform.position;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            indicator = Instantiate(powerUpIndicator, transform.position, powerUpIndicator.transform.rotation);
            StartCoroutine(PowerUpTime());
            Destroy(other.gameObject);

        }
    }

  

    IEnumerator PowerUpTime()
    {
        yield return new WaitForSeconds(powerUpTime);
        hasPowerup = false;
        Destroy(indicator);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasPowerup && collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 postion = (collision.gameObject.transform.position - transform.position) * powerUpSpeed;
            enemyRb.AddForce(postion,ForceMode.Impulse);
        }
    }
}
