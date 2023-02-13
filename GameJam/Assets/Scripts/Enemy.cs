using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Variables
    public float maxHealth = 5;
    public float currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage){
        currentHealth -= damage;
        if(currentHealth <= 0){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }
}
