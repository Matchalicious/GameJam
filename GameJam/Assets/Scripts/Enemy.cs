using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //References
    public AudioSource hurtSound;
    
    //Variables
    public float maxHealth = 5;
    public float currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage){
        hurtSound.Play();
        currentHealth -= damage;
        if(currentHealth <= 0){
            Invoke("Die", .1f);
        }
    }

    void Die(){
        Destroy(gameObject);
    }
}
