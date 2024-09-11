using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 30;
    private float jumpHeight = 5;
    private bool grounded = true;
    private Vector3 topPos;
    private Vector3 rightPos;
    private Vector3 leftPos;
    private Vector3 bottomPos;
    Rigidbody playerRb; 

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        topPos = new Vector3(0, 0.5f, 24.4f);
        rightPos = new Vector3(-3, 0.5f, 0);
        leftPos = new Vector3(-3, 0.5f, 0);
        bottomPos = new Vector3(-3, 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        playerMovementHandler(); //Check to see if the player is moving
        playerBarrierHandler(); //Check to see if the player is OOB
        
    }

    void OnCollisionEnter(Collision collision) //When the player touches the ground, update grounded to say so
    {
        if(collision.gameObject)
        {
            grounded = true;            
        }
    }
    void playerMovementHandler() //If the player presses a movement key, add force to them to move them in that direction
    {
        if(Input.GetKey(KeyCode.W)){
            playerRb.AddForce(Vector3.forward * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        if(Input.GetKeyUp(KeyCode.W)){
            playerRb.AddForce(Vector3.forward / 2, ForceMode.VelocityChange);
        }
        if(Input.GetKey(KeyCode.A)){
            playerRb.AddForce(Vector3.left * speed * Time.deltaTime,ForceMode.VelocityChange);
        }
        if(Input.GetKeyUp(KeyCode.A)){
            playerRb.AddForce(Vector3.left / 2, ForceMode.VelocityChange);
        }
        if(Input.GetKey(KeyCode.S)){
            playerRb.AddForce(Vector3.back * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        if(Input.GetKeyUp(KeyCode.S)){
            playerRb.AddForce(Vector3.back / 2, ForceMode.VelocityChange);
        }
        if(Input.GetKey(KeyCode.D)){
            playerRb.AddForce(Vector3.right * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        if(Input.GetKeyUp(KeyCode.D)){
            playerRb.AddForce(Vector3.right / 2, ForceMode.VelocityChange);
        }
        if(Input.GetKeyDown(KeyCode.Space) && grounded){
            grounded = false;
            playerRb.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
        }
    }
    void playerBarrierHandler() //If the player is OOB, stop them from moving.
    {
        if (transform.position.z > 24.4f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 24.4f);
            playerRb.velocity = Vector3.zero;
        }
        else
        {
            if (transform.position.z < -8.5)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -8.5f);
                playerRb.velocity = Vector3.zero;
            }
        }
        if (transform.position.y < -5)
        {
            transform.position = new Vector3(0, 0.5f, 0);
            playerRb.velocity = Vector3.zero;
        }
    }
}
