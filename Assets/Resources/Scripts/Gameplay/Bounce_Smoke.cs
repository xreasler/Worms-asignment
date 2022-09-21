using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Bounce_Smoke : MonoBehaviour
{
    public float BouncingForce = 2f;
    private Rigidbody rb;
 
    private void Start()
    {
    }
 
    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
        
        if (other.tag == "Player")
            rb.AddForce(Vector3.up * BouncingForce);
    }
}


