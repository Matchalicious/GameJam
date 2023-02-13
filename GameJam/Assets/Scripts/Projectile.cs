using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Variables
    public float speed; 
    public float knockback; 
    public float damage; 
    
    void FixedUpdate(){
        Vector3 prevPos = transform.position; //stores starting pos
        transform.Translate(Vector2.right * speed); //moves projectile

        RaycastHit2D hit = (Physics2D.Linecast(prevPos, transform.position));

        if (hit.rigidbody != null)
        {
            hit.rigidbody.AddForce(-hit.normal * knockback, ForceMode2D.Impulse);
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null){
                enemy.TakeDamage(damage);
            }
        }

        if (hit.collider != null){
            Destroy(gameObject);
        }
        
    }
}
