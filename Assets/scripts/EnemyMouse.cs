using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMouse : MonoBehaviour
{

	private Rigidbody rb;
	public Transform Player;

	public Transform Mouse;
	public Transform idlePosition;
	public Transform idlePosition2;
	public float speed = 1.0f;
	
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(Player.position, Mouse.position) <= 5.0f)
		{
			transform.position = Vector3.MoveTowards(Mouse.position, Player.position, Time.deltaTime);
			//transform.Translate(Player.position * Time.deltaTime);
		}
		
		else
		{
			transform.position = Vector3.MoveTowards(Mouse.position, idlePosition.position, Time.deltaTime);
		
			
		}
		

		
		

		
		
		
	}

	
}
