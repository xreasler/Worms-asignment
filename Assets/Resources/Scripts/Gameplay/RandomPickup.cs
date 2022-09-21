using UnityEngine;
using System.Collections;
 
public class RandomPickup : MonoBehaviour
{
    public GameObject Spawner;
    private Vector3 origianlpos;
    public GameObject[] prefabs = new GameObject[9];
    private void Start()
    {
        InvokeRepeating("Spawn", 5.0f, 50f);
    }
    public void Spawn () 
    {
        for(int p = 0; p < prefabs.Length; p++)
        
        {
            prefabs[p] = Resources.Load("Prefab/Weapons/Prefab" + p) as GameObject;
        }
        
        
        Instantiate(prefabs[Random.Range(0, prefabs.Length)], Spawner.transform.position, Quaternion.Euler(0,0,0));
    }
}
