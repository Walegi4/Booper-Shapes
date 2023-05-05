using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    //Jumping power for the player object
    [Header("Default Jumping Power")]
    public float jumpPower = 6f;
    //True or false if the object
    //is on the ground
    [Header("Boolean isGrounded")]
    public bool isGrounded = false;
    //Position of the object
    float posX = 0.0f;
    //Rigidbody2D of the object
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //Variable rb equals to Rigidbody2D
        //component
        rb = transform.GetComponent<Rigidbody2D>();
        //Variable posX equals to position
        //of the object on the x axis
        posX = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //If the Spacebar is pressed and
        //object is on the ground and
        //the game is playing
        if(Input.GetKey(KeyCode.Space) && isGrounded)
        {
            //Adds force to the object
            //to jump upwards based on
            //jump power, mass, and
            //gravity
            rb.AddForce(Vector3.up * (jumpPower * rb.mass * rb.gravityScale * 20.0f));
        }
    }
}
