using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public GameObject me;
    public float hpPickup;
    
    public float elapsedTime = 0;
    public float timerTarget = 10;

    public AudioClip healhPickup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= timerTarget) 
        {
            Destroy(me);
            elapsedTime = 0;
        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        Target target = other.gameObject.GetComponent<Target>();
        
        if (target != null)
        {
            target.GetHealth(hpPickup);
            AudioSource.PlayClipAtPoint(healhPickup, transform.position);
           
            
            Destroy(me); 
        }
        
    }

    
}
