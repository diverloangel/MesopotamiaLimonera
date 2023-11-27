using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    public static IsGrounded instance;
    private void Awake()
    {
        instance = this;
    }
    public bool isGrounded;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "ground") 
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }
}
