using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public float DistanceGround;

    public bool isGrounded = false; 

    // Start is called before the first frame update
    void Start()
    {
        DistanceGround = GetComponent<Collider> ().bounds.extents.y; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!Physics.Raycast(transform.position + 0.1f * Vector3.up, -Vector3.up, 1.0f))
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true; 
        }
    }

}
