using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EZCameraShake;

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
    bool isMid = false;
    bool isLight = false;
    bool isHeavy = false;
    public float shakeMag = 1f;
    public float shakeRough = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sceneManager = GameObject.FindWithTag("Manager");
    }

    //These set the selected body type
    public void Heavy(){
        isHeavy = true;
    }
    public void Mid(){
        isMid = true;
    }
    public void Light(){
        isLight = true;
    }

    //Sets stats to appropriate amount once game actually begins
    public void GameStart(){
        if(isMid){
            maxHealth = 10f;
            rb.drag = 3f;
            rb.mass = 1f;
        }
        if(isLight){
            maxHealth = 5f;
            rb.drag = 5f;
            rb.mass = .5f;
        }
        if(isHeavy){
            maxHealth = 20f;
            rb.drag = 2f;
            rb.mass = 1.5f;
        }
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float damage){
        hurtSparks.Play();
        hurtSound.Play();
        CameraShaker.Instance.ShakeOnce(shakeMag, shakeRough, .1f, 2f);
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
        CameraShaker.Instance.ShakeOnce(shakeMag + 1f, shakeRough + 1f, .1f, 3f);
        Instantiate(deathSparks, rb.position, Quaternion.identity);
        Instantiate(deathSound, rb.position, Quaternion.identity);
        sceneManager.GetComponent<Manager>().ReloadRequest();
        Destroy(gameObject);
    }

}
