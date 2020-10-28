using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public PlayerControls player;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerControls> ();   
    }

   public void MakePlayerJump()
    {
        player = FindObjectOfType<PlayerControls>();
        player.Jump = true; 
    }
}
