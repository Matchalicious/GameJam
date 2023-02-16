using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swarmer : MonoBehaviour
{
    //References
    GameObject player;
    Rigidbody2D playerRb;
    Rigidbody2D rb;
    Player playerHealth;

    //Variables
    public float speed = 10f;
    public float damage = 1f;
    
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


    }

    void FixedUpdate()
    {
        if(playerRb != null){
            Vector2 lookDir = playerRb.position-rb.position; //stores vector between player position and enemy position
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg; //converts that vector to an angle
            rb.rotation = angle; //looks in that angle
            rb.AddRelativeForce(Vector2.right * speed, ForceMode2D.Force); //applies force in that direction
        }
        
    }

    //Detects collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            playerHealth.TakeDamage(damage);
        }
        
    }
}
