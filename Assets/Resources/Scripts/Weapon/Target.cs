using UnityEngine;

public class Target : MonoBehaviour {
    public float health;
    public AudioClip hurt;
    public AudioClip death;
    

    
    

    void Update() {
        if(health <= 0) {
            AudioSource.PlayClipAtPoint(death, transform.position);
            Destroy(gameObject);
            SwitchManager.instance.GameOver();
        }
    }

    /// 'Hits' the target for a certain amount of damage
    public void Hit(float damage) {
        health -= damage;
        AudioSource.PlayClipAtPoint(hurt, transform.position);
    }

    public float GetHealth()
    {
        return health;
    }

    
    
}