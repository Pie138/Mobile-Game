using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody rb;
    //Rigidbody rig;
    CapsuleCollider collider;

    public float jump;
    public bool isJumping;
    public bool Jump;
    private Animator animator;
    public float LandSpeed = -5;
    private bool PlayerCollide;
    float originalHeight;
    public float reducedHeight;
    public float slideSpeed = 10f;
    public bool isSliding;
    

    


    CheckGround checkGround;

    [SerializeField] private Transform[] LevelParts;
    public GameObject gameOverPanel;

    public float SlideTimer = 2.0f;
    [SerializeField] private Transform CameraRig;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();

        checkGround = GetComponentInChildren<CheckGround>();

        Time.timeScale = 1;

        
        collider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        originalHeight = collider.height;

       
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rb.velocity = new Vector3(10, rb.velocity.y);                           

        if (checkGround.isGrounded == false)
        {                                                                   //these if statements play the jump animation
            animator.SetBool("is_in_air", true);                            
            animator.SetBool("GoingUp", rb.velocity.y > LandSpeed);

            animator.SetBool("Sliding", true);
            animator.SetBool("DoingSlide", slideSpeed > LandSpeed);

        }
        else
        {
            animator.SetBool("is_in_air", false);
            animator.SetBool("GoingUp", false);

            animator.SetBool("Sliding", false);
        }

        //if (Input.GetKeyDown("s") && Input.GetKeyDown("w"))
        //Slide();
        // else if (Input.GetKeyUp("s"))
        // GoingUp();
    }

    public void OnJump()
    {
        if (!isJumping && checkGround.isGrounded)
        {
            rb.AddForce(0, jump * Time.deltaTime, 0, ForceMode.VelocityChange);     //this if statement makes the player jump
            GetComponent<Rigidbody>().AddForce(Vector3.up * 200);
        }
    }

    public void Slide()
    {
        collider.height = reducedHeight;
        rb.AddForce(transform.forward * slideSpeed, ForceMode.VelocityChange);
        Invoke("GoingUp", 2);

        if (checkGround.isGrounded == true)
        {
            animator.SetBool("Sliding", true);
        }
        
        else
        {
            animator.SetBool("Sliding", false);
        }
    }

    public void GoingUp()
    {
        collider.height = originalHeight;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerCollide")
        {
            Time.timeScale = 0;
            FindObjectOfType<GameManager>().EndGame();
        }

        if (other.CompareTag("PlayerCollide"))
        {
           gameOverPanel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerCollide"))
        {
            gameOverPanel.SetActive(false);
        }
    }

}
