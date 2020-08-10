using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody rb;

    public float jump;
    private bool isJumping; 
   
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(10, rb.velocity.y);

        if (Input.GetKeyDown("mouse 0") && !isJumping)
        {
            rb.AddForce(0, jump * Time.deltaTime, 0, ForceMode.VelocityChange);
            GetComponent<Rigidbody>().AddForce(Vector3.up * 200);
        }
    }

    private void OnCollisionEnter()
    {
        isJumping = false;
    }

    private void OnCollisionExit()
    {
        isJumping = true;
    }

    
}