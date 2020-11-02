using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 10;
    private float topBound = -10.3f;
    private float bottomBound = 17.2f;
    private float leftBound = 21.5f;
    private float rightBound = -20.1f;
    private float rebound = 15.1f;
    private bool hasPowerups = false;

    private Rigidbody playerRB;

   
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

  
    void Update()
    {
        MovePlayer(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        CheckBound();
    }

    private void MovePlayer(float horizontal, float vertical)
    {
        playerRB.AddForce(Vector3.forward * speed * -vertical,ForceMode.Acceleration);
        playerRB.AddForce(Vector3.right * speed * -horizontal, ForceMode.Acceleration);
    }

    private void CheckBound()
    {
        if(transform.position.z > bottomBound)
        {
           transform.position = new Vector3(transform.position.x, transform.position.y, bottomBound);
            playerRB.AddForce(Vector3.forward *  -rebound, ForceMode.Impulse);
        }
       else if (transform.position.z < topBound)
        {
           transform.position = new Vector3(transform.position.x, transform.position.y, topBound);
           playerRB.AddForce(Vector3.forward *  rebound, ForceMode.Impulse);
        }

        if (transform.position.x > leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
            playerRB.AddForce(Vector3.right * -rebound, ForceMode.Impulse);
        }
        else if (transform.position.x < rightBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
            playerRB.AddForce(Vector3.right * rebound, ForceMode.Impulse);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerups"))
        {
            Destroy(other.gameObject);
            hasPowerups = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //collide with enemy
        }
    }


}
