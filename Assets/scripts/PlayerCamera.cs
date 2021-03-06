﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

  public GameObject player;       //Public variable to store a reference to the player game object
    //public Transform playerPos;
    


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    public float ballSize;
    
    private float HorizontalAxis;
    public float rotateSpeed = 1f;
    float camRotateSpeed = 180f;
    public float rotateAround = 70f;
    public Transform playerTrans;
    public float cameraHeight = 1.0f;
    public float offsetHeight;
    float cameraPan = 400f;
   

    // Use this for initialization
    void Start () 
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
        rotateAround = playerTrans.eulerAngles.y - 45f;
      //  ballSize = 1.0f;

    }
    
    // LateUpdate is called after Update each frame
    void LateUpdate () 
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;

        //Zoom out more if ball gets bigger
        if (ballSize > 1.0f && ballSize <= 2.0f)
        {
            transform.position = player.transform.position + offset * offsetHeight;
        }
        
        Quaternion rotation = Quaternion.Euler(cameraHeight, rotateAround, cameraPan);
        
        transform.LookAt(playerTrans);
        
        
    }

    void Update()
    {
        
        offset = Quaternion.AngleAxis (Input.GetAxis("Rotate"), Vector3.up) * offset;
        transform.position = playerTrans.position + offset; 
        transform.LookAt(playerTrans.position);
    }
    
    
}
