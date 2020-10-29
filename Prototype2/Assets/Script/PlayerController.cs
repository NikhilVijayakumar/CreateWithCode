using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    public float speed = 5.0f;
    public float xRange = 10.0f;
    public GameObject projectile;
  
    void Update()
    {
       
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        else
        {
            horizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectile,transform.position, projectile.transform.rotation);
            
        }
        
    }
}
