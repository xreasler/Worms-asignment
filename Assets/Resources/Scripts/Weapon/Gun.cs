using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Gun : MonoBehaviour
{

    public AudioClip outOfAmmo;
    public AudioClip fire;
    public Transform muzzleflash;
    public GameObject me;
    
    
    public enum ShootState {
        Ready,
        Shooting,
        Reloading
    }

   
   private float muzzleOffset;

    [Header("Magazine")]
    public GameObject round;
    public int ammunition;

    [Range(0.5f, 10)] public float reloadTime;

    public int remainingAmmunition;

    [Header("Shooting")]
    
    [Range(0.25f, 25)] public float fireRate;

    
    public int roundsPerShot;

    [Range(0.5f, 100)] public float roundSpeed;

    
    [Range(0, 45)] public float maxRoundVariation;

    private ShootState shootState = ShootState.Ready;

    
    private float nextShootTime = 0;

    void Start() {
        
        remainingAmmunition = ammunition;
    }

    void Update() 
    {
        switch(shootState) 
        {
            case ShootState.Shooting:
                // If the gun is ready to shoot again...
                if(Time.time > nextShootTime) 
                {
                    shootState = ShootState.Ready;
                }
                break;
            case ShootState.Reloading:
                // If the gun has finished reloading...
                if(Time.time > nextShootTime) 
                {
                    remainingAmmunition = ammunition;
                    shootState = ShootState.Ready;
                }
                break;
        }
    }

    /// Attempts to fire the gun
    public void Shoot() {
        // Checks that the gun is ready to shoot
        if(shootState == ShootState.Ready) 
        {
            for(int i = 0; i < roundsPerShot; i++) {
                // Instantiates the round at the muzzle position
                Debug.Log("Trying to shoot");
                AudioSource.PlayClipAtPoint(fire, transform.position);
                //Instantiate(muzzleflash, transform.position, Quaternion.identity);
                //TurnManager.GetInstance().TriggerChangeTurn();
                GameObject spawnedRound = Instantiate(
                    round,
                    transform.position + transform.forward * muzzleOffset,
                    transform.rotation
                    
                   
                );
                
                

                // Add a random variation to the round's direction
                spawnedRound.transform.Rotate(new Vector3(
                    Random.Range(-1f, 1f) * maxRoundVariation,
                    Random.Range(-1f, 1f) * maxRoundVariation,
                    0
                ));

                Rigidbody rb = spawnedRound.GetComponent<Rigidbody>();
                rb.velocity = spawnedRound.transform.forward * roundSpeed;
            }

            remainingAmmunition--;
            if(remainingAmmunition > 0) 
            {
                nextShootTime = Time.time + (1 / fireRate);
                shootState = ShootState.Shooting;
            } else 
            {
                Reload();
            }
        }
    }

   

    /// Attempts to reload the gun
    public void Reload() {
        // Checks that the gun is ready to be reloaded
        
            if (shootState == ShootState.Ready)
            {
                AudioSource.PlayClipAtPoint(outOfAmmo, transform.position);
                
                nextShootTime = Time.time + reloadTime;
                shootState = ShootState.Reloading;
            }
        
    }
}