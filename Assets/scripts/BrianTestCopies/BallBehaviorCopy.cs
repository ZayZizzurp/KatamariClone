﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor;
using UnityEngine;

public class BallBehaviorCopy : MonoBehaviour
{

	public float maxSpeed = 150; //max speed ball can reach
	public float minSpeed = 0; //min speed it can go to
	public float speed = 0; //speed of ball
	public float acceleration = 2; //acceleration of the ball as you go forward
	public float turn; //turn amount
	private float massBall = 25; //mass of the ball as it grows
	private float collectMass = 2; //mass of collectables 
	public Bounds bounds;
	public SphereCollider originalBallDiameter;
	public float ballTimer = 0f;
	public float fastTimer = 0f;
	private Rigidbody rb;

	//EDIT ////////////
	public float ballMass;
	public float ballMassCounter;
	public GameObject collectable;

	private SphereCollider s_Collider;
	private float s_Scalex;
	private float s_Scaley;
	private float s_Scalez;
	public SphereCollider myCollider;
	
	
	
	
	
	//EDIT ENDS HERE///////////
	


	void Start ()
	{
		rb = GetComponent<Rigidbody>(); //getting rigidbody of ball
		bounds = originalBallDiameter.bounds;
		;
		//EDIT///////////
		myCollider = GetComponent<SphereCollider>();
		ballMassCounter = 0;
		s_Collider = GetComponent<SphereCollider>();
		s_Scalex = 12.0f;
		s_Scaley=12.0f;
		s_Scalez = 12.0f;
		//abs = myCollider.radius;



		//EDIT ENDS HERE/////////
	}

	
	
	
	
	//EDIT///////////
/*
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "collectable")
		{
		ballMassCounter += 1;
	}

		if (ballMassCounter >= 1) ;
		{
			
		}
	}
	
	*/
	//EDIT ENDS HERE//////////


	void Update()
	{
		//EDIT///////////
		if (Input.GetKey(KeyCode.F))
		{
			myCollider.radius += 20f;
		}
		
		//EDIT ENDS HERE//////////////
	}
	void FixedUpdate ()
	{
		
		
		ballTimer += Time.deltaTime;
		Debug.Log(massBall);
		//Debug.Log(massBall); //printing out the mass that has been added to the ball
		float moveHorizontal = Input.GetAxis ("Horizontal"); //moving left and right
		float moveVertical = Input.GetAxis ("Vertical"); //moving up and down
		float RotateVertical = Input.GetAxis("Rotate");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		if (Input.GetKey((KeyCode.UpArrow)) || Input.GetKey((KeyCode.DownArrow))|| Input.GetKey((KeyCode.RightArrow)) || Input.GetKey((KeyCode.LeftArrow)) || Input.GetKey((KeyCode.W))|| Input.GetKey((KeyCode.A)) || Input.GetKey((KeyCode.S)) || Input.GetKey((KeyCode.D)))
		{
			speed = acceleration + speed;
		}
		else
		{
			speed = speed - acceleration;
		}

		if (ballTimer > 15 && Input.GetKey(KeyCode.Space)) //speed up when pressing space
		{
			fastTimer += Time.deltaTime;
			maxSpeed = 350;
			speed += 50;
			
		}
		else
		{
			maxSpeed = 240;
		}

		if (fastTimer > 5)
		{
			maxSpeed = 240;
			fastTimer = 0;
			ballTimer = 0;
		}
		
		//Debug.Log(speed);
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

//	void OnCollisionEnter(Collision col)
//	{
//		if (col.gameObject.tag == "collectable") //if ball runs into an object
//		{
//			if (massBall < 35 && col.rigidbody.mass < 3)
//			{
//				
//				//rb.mass += col.rigidbody.mass; //mass of ball is now added to mass of collectable
//				massBall += col.rigidbody.mass;
//				//massBall += collectMass; //mass collected is added to variable
//				Destroy(col.rigidbody); //getting rid of the rigidbody on collectable
//				col.transform.parent = transform; //parenting object to ball
//				//maxSpeed += 5;
//				bounds.Encapsulate(transform.localScale + col.transform.localScale);
//				//originalBallDiameter.radius += 0.2f;
//				col.gameObject.GetComponent<CapsuleCollider>().enabled = false;
//				col.gameObject.GetComponent<BoxCollider>().enabled = false;
//				col.gameObject.GetComponent<SphereCollider>().enabled = true;
//				originalBallDiameter.radius += 0.1f;
//			}
//
//			if (massBall > 34 && rb.mass < 60 && col.rigidbody.mass < 7)
//			{
//				//rb.mass += col.rigidbody.mass; //mass of ball is now added to mass of collectable
//				massBall += col.rigidbody.mass;
//				//massBall += collectMass; //mass collected is added to variable
//				Destroy(col.rigidbody); //getting rid of the rigidbody on collectable
//				col.transform.parent = transform; //parenting object to ball
//				//maxSpeed += 20;
//				bounds.Encapsulate(transform.localScale + col.transform.localScale);
//				col.gameObject.GetComponent<CapsuleCollider>().enabled = false;
//				col.gameObject.GetComponent<BoxCollider>().enabled = false;
//				col.gameObject.GetComponent<SphereCollider>().enabled = true;
//				originalBallDiameter.radius += 0.1f;
//
//
//
//
//			}
//			if (massBall > 60 && rb.mass < 100 && col.rigidbody.mass < 15)
//			{
//				massBall += col.rigidbody.mass;
//				//rb.mass += col.rigidbody.mass; //mass of ball is now added to mass of collectable
//				//massBall += collectMass; //mass collected is added to variable
//				Destroy(col.rigidbody); //getting rid of the rigidbody on collectable
//				col.transform.parent = transform; //parenting object to ball
//				//maxSpeed += 40;
//				bounds.Encapsulate(transform.localScale + col.transform.localScale);
//				col.gameObject.GetComponent<CapsuleCollider>().enabled = false;
//				col.gameObject.GetComponent<BoxCollider>().enabled = false;
//				col.gameObject.GetComponent<SphereCollider>().enabled = true;
//				originalBallDiameter.radius += 0.1f;
//
//
//
//			}
//		}
//		
//	}
	
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "collectable")
			if (massBall < 35 && col.rigidbody.mass < 3 && col.rigidbody.mass < rb.mass)
			{
				bounds.Encapsulate(transform.localScale + col.transform.localScale);
				rb.mass += col.rigidbody.mass;
				massBall += col.rigidbody.mass;
				Destroy(col.rigidbody);
				col.transform.parent = transform;
				col.gameObject.GetComponent<BoxCollider>().enabled = false;
			}
		
		if (massBall > 34 && col.rigidbody.mass < 7 && col.rigidbody.mass < rb.mass)
		{
			bounds.Encapsulate(transform.localScale + col.transform.localScale);
			rb.mass += col.rigidbody.mass;
			massBall += col.rigidbody.mass;
			Destroy(col.rigidbody);
			col.transform.parent = transform;
			col.gameObject.GetComponent<BoxCollider>().enabled = false;
		}
		if (massBall > 60 && col.rigidbody.mass < 15 && col.rigidbody.mass < rb.mass)
		{
			bounds.Encapsulate(transform.localScale + col.transform.localScale);
			rb.mass += col.rigidbody.mass;
			massBall += col.rigidbody.mass;
			Destroy(col.rigidbody);
			col.transform.parent = transform;
			col.gameObject.GetComponent<BoxCollider>().enabled = false;
		}
		
		if (massBall > 100 && col.rigidbody.mass < 35 && col.rigidbody.mass < rb.mass)
		{
			bounds.Encapsulate(transform.localScale + col.transform.localScale);
			rb.mass += col.rigidbody.mass;
			massBall += col.rigidbody.mass;
			Destroy(col.rigidbody);
			col.transform.parent = transform;
			col.gameObject.GetComponent<BoxCollider>().enabled = false;
		}
	}
	
	
}
