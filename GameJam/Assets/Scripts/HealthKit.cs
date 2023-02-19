using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour
{
    //References
    GameObject player;
    Player playerHealth;

    //Variables
    public float healAmount = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if(player != null){

            playerHealth = player.GetComponent<Player>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            playerHealth.Heal(healAmount);
            Destroy(gameObject);
        }
        
    }
}
