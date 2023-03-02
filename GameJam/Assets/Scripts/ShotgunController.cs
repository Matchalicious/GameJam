using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EZCameraShake;

public class ShotgunController : MonoBehaviour
{
    //Variables
    private float nextTimeToFire = 0f;
    public float fireRate = 5f;
    public float projectileDamage = 5f;
    public float projectileKnockback = 2f;
    public float projectileSpeed = 0.3f;
    public float kick = 1f;
    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public float shakeMag = 1f;
    public float shakeRough = 1f;


    //References
    public Transform spawnPointZero;
    public Transform spawnPointOne;
    public Transform spawnPointTwo;
    public GameObject projectile;
    public Rigidbody2D playerRb; 
    public AudioSource shootSound;
    public AudioSource reloadSound;  
    public TextMeshProUGUI ammoDisplay;

// Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void OnEnable(){
        isReloading = false;
    }

    // Update is called once per frame
    void Update()
    {
        ammoDisplay.text = currentAmmo.ToString();
        if(isReloading){
            return;
        }
        if (currentAmmo <= 0){
            Debug.Log("Reloading...");
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetKeyDown(KeyCode.R)){
            StartCoroutine(Reload());
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
    }

    void Shoot(){
        currentAmmo = currentAmmo - 1;
        shootSound.Play();
        CameraShaker.Instance.ShakeOnce(shakeMag, shakeRough, .1f, 1f);
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

    IEnumerator Reload(){
        isReloading = true;
        reloadSound.Play();
        CameraShaker.Instance.ShakeOnce(shakeMag + 1, shakeRough, .1f, 1f);
        yield return new WaitForSeconds(reloadTime);
        CameraShaker.Instance.ShakeOnce(shakeMag + 1, shakeRough, .1f, 1f);
        reloadSound.Play();
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
