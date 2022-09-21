using System.Collections;
using UnityEngine;

public class Round : MonoBehaviour 
{
    public float damage;
    [SerializeField] private Transform blood;
    [SerializeField] private Transform spark;

    void OnCollisionEnter(Collision other)
    {
        Target target = other.gameObject.GetComponent<Target>();
        
        if (target != null)
        {
            target.Hit(damage);
            Instantiate(blood, transform.position, Quaternion.identity);
            
            Destroy(gameObject); 
        }
        else
        {
            Instantiate(spark, transform.position, Quaternion.identity);
            
        }
        
        
        
        
       

    }

    
    
}