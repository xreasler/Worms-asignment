using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRotate : MonoBehaviour
{

    public Rigidbody rb; 
    Vector3 m_EulerAngleVelocity;
    void Start()
    {
      rb =  GetComponent<Rigidbody>();
      m_EulerAngleVelocity = new Vector3(0, 20, 0);
      
      
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
