using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //References
    public ParticleSystem hurtSparks;
    public GameObject deathSparks;
    public AudioSource hurtSound;
    public GameObject deathSound;
    public AudioSource healSound;
    GameObject sceneManager;
    Rigidbody2D rb;
    public Healthbar healthBar;

    //Variables
    public float maxHealth = 10;
    public float currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sceneManager = GameObject.FindWithTag("Manager");
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float damage){
        hurtSparks.Play();
        hurtSound.Play();
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0){
            Die();
        }
    }

    public void Heal(float healAmount){
        healSound.Play();
        currentHealth += healAmount;
        healthBar.SetHealth(currentHealth);
        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
    }

    void Die(){
        Instantiate(deathSparks, rb.position, Quaternion.identity);
        Instantiate(deathSound, rb.position, Quaternion.identity);
        sceneManager.GetComponent<Manager>().ReloadRequest();
        Destroy(gameObject);
    }

}
