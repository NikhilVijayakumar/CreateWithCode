using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator animator;
    private float jumpForce = 650;
    private float gravityModifier = 2f;
    private bool isGrounded = true;
    public bool gameover;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && Input.GetButtonDown("Jump") && !gameover)
        {
            playerRB.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isGrounded = false;
            animator.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameover = true;
            animator.SetBool("Death_b",true);
            animator.SetInteger("DeathType_int",1);
            Debug.Log("Game over !! !!");
        }

    }
}
