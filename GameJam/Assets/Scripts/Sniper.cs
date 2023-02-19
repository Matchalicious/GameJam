using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    //References
    GameObject player;
    Rigidbody2D playerRb;
    Rigidbody2D rb;
    Player playerHealth;
    public AudioSource blastSound;
    public Transform spawnerTransform;
    public GameObject projectile;

    //Variables
    private float nextTimeToFire = 0f;
    public float fireRate = .5f;
    public float detectionRange = 11f;
    public bool alerted = false;
    

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        if(player != null){
            playerRb = player.GetComponent<Rigidbody2D>();
            playerHealth = player.GetComponent<Player>();
        }
    }

    void Update()
    {
        
        if (Time.time >= nextTimeToFire && alerted == true && player != null){
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }

        if(player != null){
            if (Vector2.Distance(rb.position, playerRb.position) < detectionRange){
            alerted = true;
        }
        }
    }

    void FixedUpdate()
    {
        if(playerRb != null && alerted == true){
            Vector2 lookDir = playerRb.position-rb.position; //stores vector between player position and enemy position
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg; //converts that vector to an angle
            rb.rotation = angle; //looks in that angle
        }
        
    }

    void Shoot(){
        blastSound.Play();
        Instantiate(projectile, spawnerTransform.position, spawnerTransform.rotation);

    }
}
