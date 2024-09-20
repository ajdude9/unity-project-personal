using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 6;
    private float jumpHeight = 5;
    private bool grounded = true;
    private Vector3 topPos;
    private Vector3 rightPos;
    private Vector3 leftPos;
    private Vector3 bottomPos;
    Rigidbody playerRb;
    private GameObject focalPoint; 

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        playerMovementHandler(); //Check to see if the player is moving
        
        
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
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.transform.Translate(focalPoint.transform.forward * speed * forwardInput * Time.deltaTime);
        float horizontalInput = Input.GetAxis("RightLeft");
        playerRb.transform.Translate(focalPoint.transform.right * speed * horizontalInput * Time.deltaTime);
    }

    // If Player collides with powerup, trigger powerup routines
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);            
        }
    }
}
