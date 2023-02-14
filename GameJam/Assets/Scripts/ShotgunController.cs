using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunController : MonoBehaviour
{
    //Variables
    private float nextTimeToFire = 0f;
    public float fireRate = 5f;
    public float projectileDamage = 5f;
    public float projectileKnockback = 2f;
    public float projectileSpeed = 0.3f;
    public float kick = 1f;


    //References
    public Transform spawnPointZero;
    public Transform spawnPointOne;
    public Transform spawnPointTwo;
    public GameObject projectile;
    public Rigidbody2D playerRb; 
    public AudioSource shootSound;   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
    }

    void Shoot(){
        shootSound.Play();
        playerRb.AddRelativeForce(Vector2.left * kick, ForceMode2D.Impulse);
        
        var projectileGO = Instantiate(projectile, spawnPointZero.position, spawnPointZero.rotation).GetComponent<Projectile>();
        projectileGO.speed = projectileSpeed;
        projectileGO.knockback = projectileKnockback;
        projectileGO.damage = projectileDamage;

        var projectileGOone = Instantiate(projectile, spawnPointOne.position, spawnPointOne.rotation).GetComponent<Projectile>();
        projectileGOone.speed = projectileSpeed;
        projectileGOone.knockback = projectileKnockback;
        projectileGOone.damage = projectileDamage;

        var projectileGOtwo = Instantiate(projectile, spawnPointTwo.position, spawnPointTwo.rotation).GetComponent<Projectile>();
        projectileGOtwo.speed = projectileSpeed;
        projectileGOtwo.knockback = projectileKnockback;
        projectileGOtwo.damage = projectileDamage;
    }
}
