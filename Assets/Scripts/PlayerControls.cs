using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody rb;

    public float jump;
    public bool isJumping;
    public bool Jump;
    private Animator animator;
    public float LandSpeed = -5;

    CheckGround checkGround;

    [SerializeField] private Transform[] LevelParts;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();

        checkGround = GetComponentInChildren<CheckGround>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rb.velocity = new Vector3(10, rb.velocity.y);


        if (checkGround.isGrounded == false)
        {
            animator.SetBool("is_in_air", true);
            animator.SetBool("GoingUp", rb.velocity.y > LandSpeed);
        }
        else
        {
            animator.SetBool("is_in_air", false);
            animator.SetBool("GoingUp", false);
        }

    }

    public void OnJump()
    {
        if (!isJumping && checkGround.isGrounded)
        {
            rb.AddForce(0, jump * Time.deltaTime, 0, ForceMode.VelocityChange);
            GetComponent<Rigidbody>().AddForce(Vector3.up * 200);
        }
    }

    public void Slide()
    {

    }
}