using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    //Variables
    private float nextTimeToFire = 0f;
    public float fireRate = 5f;
    public float projectileDecay = 10f;
    public float projectileDamage = 5f;
    public float projectileKnockback = 2f;
    public float projectileSpeed = 0.3f;


    //References
    Transform spawnerTransform;
    public GameObject projectile;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnerTransform = GetComponent<Transform>(); 
    }

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
        var projectileGO = Instantiate(projectile, spawnerTransform.position, spawnerTransform.rotation).GetComponent<Projectile>();
        projectileGO.speed = projectileSpeed;
        projectileGO.knockback = projectileKnockback;
        projectileGO.damage = projectileDamage;
    }
}
