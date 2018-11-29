using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor;
using UnityEngine;

public class ballBehavior : MonoBehaviour
{

	public float maxSpeed = 150; //max speed ball can reach
	public float minSpeed = 0; //min speed it can go to
	public float speed = 0; //speed of ball
	public float acceleration = 2; //acceleration of the ball as you go forward
	public float turn; //turn amount
	private float massBall; //mass of the ball as it grows
	private float collectMass = 2; //mass of collectables 
	public Bounds bounds;
	public SphereCollider originalBallDiameter;
	public float ballTimer = 0f;
	public float fastTimer = 0f;
	private collactable collectableScript;
	private Rigidbody rb;

	void Start ()
	{
		collectableScript = GetComponent<collactable>();
		rb = GetComponent<Rigidbody>(); //getting rigidbody of ball
		bounds = originalBallDiameter.bounds;
	}

	

	void FixedUpdate ()
	{
		ballTimer += Time.deltaTime;
		Debug.Log(ballTimer);
		//Debug.Log(massBall); //printing out the mass that has been added to the ball
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

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "collectable") //if ball runs into an object
		{
			
         			rb.mass += col.rigidbody.mass; //mass of ball is now added to mass of collectable
			         massBall += collectMass; //mass collected is added to variable
         		    Destroy(col.rigidbody); //getting rid of the rigidbody on collectable
                     col.transform.parent = transform; //parenting object to ball
			         
			         bounds.Encapsulate(transform.localScale + col.transform.localScale);
         			
         		}
		
	}
	
	
	
}
