using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 allMove;
    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        //Gather inputs
        allMove.x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        allMove.y = Input.GetAxisRaw("Vertical") * moveSpeed;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }
    //I used fixed update to make character speed framerate independent
    void FixedUpdate()
    {
        //Creates the actual movement by adding force to the player
        rb.AddForce(allMove, ForceMode2D.Force);

        //Points player towards mouse
        Vector2 lookDir = mousePos-rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
