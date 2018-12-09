using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseBehavior2 : MonoBehaviour
{

	public ballBehavior player;
	void Update () {
		//step 1: define a ray
		//not vector3.forward, that's the world's forward
		// transform.forward = this object's current forward
		Ray myRay = new Ray(transform.position, transform.forward);
		
		//step 2: define a distance
		float myMaxDis = 0.5f;
		
		//step 3: visualize the raycast (optional)
		Debug.DrawRay(myRay.origin, myRay.direction * myMaxDis, Color.green);
		
		//step 4: actually make ray!
		if (Physics.Raycast(myRay, myMaxDis))
		{
			//if it returns true, there's a wall so we should turn to avoid it
			int randomNumber = Random.Range(0, 100);
			//if less than 50, turn left; otherwise, turn right
			if (randomNumber < 50)
			{
				transform.Rotate(0f, -90f, 0f);
			}
			else
			{
				transform.Rotate(0f, 90f,0f);
			}

		}

		else
		{
			//go forward if raycast is False
			transform.Translate(0f,0f,Time.deltaTime);
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "player")
		{
			player.massBall -= 2f;
			
		}
	}
}