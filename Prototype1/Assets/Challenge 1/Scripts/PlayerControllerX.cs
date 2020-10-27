using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    private float verticalInput;
    private float horizontal;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontal);
    }
}
