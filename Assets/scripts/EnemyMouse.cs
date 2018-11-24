using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMouse : MonoBehaviour
{


	public Transform Player;

	public Transform Mouse;
	public Transform idlePosition;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(Player.position, Mouse.position) <= 5.0f)
		{
			transform.position = Vector3.MoveTowards(transform.position, Player.position, Time.deltaTime);
		}
		else
		{
			transform.position = Vector3.MoveTowards(transform.position, idlePosition.position, Time.deltaTime);
		}

		
		
		
	}

	
}
