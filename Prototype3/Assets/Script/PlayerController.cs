using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator animator;
    private AudioSource audio;
    private float jumpForce = 650;
    private float gravityModifier = 2f;
    private bool isGrounded = true;
    public bool gameover;
    public ParticleSystem dirt;
    public ParticleSystem crash;
    public AudioClip jump;
    public AudioClip death;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();  
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
            audio.PlayOneShot(jump,1.0f);
            dirt.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            dirt.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameover = true;
            dirt.Stop();
            crash.Play();
            animator.SetBool("Death_b",true);
            animator.SetInteger("DeathType_int",1);
            audio.PlayOneShot(death, 1.0f);
            Debug.Log("Game over !! !!");
        }

    }
}
