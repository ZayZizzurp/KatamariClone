using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBehavior : MonoBehaviour {

	public float speed; //speed of ball
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

		rb.AddForce (movement * speed); //how the ball is able to roll
		rb.AddTorque(transform.up * turn * moveHorizontal);// ball turn and roll
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
