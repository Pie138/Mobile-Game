using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTouch : MonoBehaviour
{
    private void OnTriggerEnter (Collider other)
    {
        GameObject.Find("Character").SendMessage("Finnish");
    }
}
