using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite : MonoBehaviour
{
    public Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        if(target != null){
            transform.position = target.position;  
        }
        else{
            Destroy(gameObject);
        }


    }
}
