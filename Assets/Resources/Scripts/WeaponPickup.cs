using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject me;
    public GameObject prefab;
    public Transform spawnpoint;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(prefab, spawnpoint.transform.position, spawnpoint.transform.rotation);
        prefab.transform.SetParent(spawnpoint);
        
        Destroy(me);
    }
    
}