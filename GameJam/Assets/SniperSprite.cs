using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperSprite : MonoBehaviour
{
    public Transform body;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler (0.0f, 0.0f, body.transform.rotation.z * -1.0f);
    }
}
