using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockP : MonoBehaviour
{
    public GameObject me;
    
    public float elapsedTime = 0;
    public float timerTarget = 10;
    
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
        
        SwitchManager.instance.MoreTime();    
        Destroy(me); 
        
        
    }
}
