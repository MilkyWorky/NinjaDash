using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaGirl : MonoBehaviour
{

    [SerializeField] private float velocity = 1.5f;

    private Rigidbody2D rigidBody;
    private CapsuleCollider2D capsuleCollider;
    private Animator animator;
    private bool isSliding;
    private bool isJumping;
    private bool canSlide;
    private AudioSource audisrc;
    [SerializeField]
    private AudioClip jump;
    [SerializeField]
    private AudioClip slide;

    private void Start()
    {
        audisrc = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        isSliding = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && !isSliding && !isJumping)
        {
            rigidBody.velocity = Vector2.up * velocity;
            animator.SetBool("Jump", true);
            animator.SetBool("Running", false);
            isJumping = true;
            canSlide = false;
            audisrc.clip = jump;
            audisrc.Play();
        }
        else if(Input.GetKeyDown(KeyCode.S) && canSlide)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Running", false);
            animator.SetBool("Slide", true);
            this.gameObject.transform.position = new Vector3(transform.position.x, -0.7f, transform.position.z);
            capsuleCollider.size = new Vector3(1, 0.5f, 1);
            //capsuleCollider.offset = new Vector3(0,-0.25f,0); 
            isSliding = true;
            audisrc.clip = slide; audisrc.Play();
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            capsuleCollider.size = new Vector3(1.9f, 5.064609f, 1);
            animator.SetBool("Slide", false);
            isSliding= false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            GameManager.Instance.GameOver();
        }

        if (collision.gameObject.CompareTag("ground"))
        {
            animator.SetBool("Running", true );
            isJumping = false;
            canSlide = true;
        }
    }
}
