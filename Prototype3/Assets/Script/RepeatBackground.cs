using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{

    private Vector3 startPostion;
    private float offset;
    // Start is called before the first frame update
    void Start()
    {
        startPostion = transform.position;
        offset = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPostion.x - offset)
        {
            transform.position = startPostion;
        }
    }
}
