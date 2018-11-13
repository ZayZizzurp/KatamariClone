﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ballBehavior : MonoBehaviour
{

	public float maxSpeed = 150;
	public float minSpeed = 0;
	public float speed = 0; //speed of ball
	public float acceleration = 2;
	public float turn; //turn amount
	private float massBall; 
	private float collectMass = 2; //mass of collectables 
	

	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>(); //getting rigidbody of ball
		
	}

	

	void FixedUpdate ()
	{
		Debug.Log(massBall); //printing out the mass that has been added to the ball
		float moveHorizontal = Input.GetAxis ("Horizontal"); //moving left and right
		float moveVertical = Input.GetAxis ("Vertical"); //moving up and down

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		if (Input.GetKey((KeyCode.UpArrow)) || Input.GetKey((KeyCode.DownArrow))|| Input.GetKey((KeyCode.RightArrow)) || Input.GetKey((KeyCode.LeftArrow)) || Input.GetKey((KeyCode.W))|| Input.GetKey((KeyCode.A)) || Input.GetKey((KeyCode.S)) || Input.GetKey((KeyCode.D)))
		{
			speed = acceleration + speed;
		}
		else
		{
			speed = speed - acceleration;
		}
		
		
		Debug.Log(speed);
		rb.AddForce (movement * speed); //how the ball is able to roll
		rb.AddTorque(transform.up * turn * moveHorizontal);// ball turn and roll
		if (speed >= maxSpeed)
		{
			speed = maxSpeed;
		}

		if (speed <= minSpeed)
		{
			speed = minSpeed;
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "collectable") //if ball runs into an object
         		{
         			rb.mass += col.rigidbody.mass; //mass of ball is now added to mass of collectable
			         massBall += collectMass; //mass collected is added to variable
         		    Destroy(col.rigidbody); //getting rid of the rigidbody on collectable
                     col.transform.parent = transform; //parenting object to ball
         			
         		}
		
	}
	
	
	
}
