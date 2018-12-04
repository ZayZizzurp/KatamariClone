using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrianPlayerController : MonoBehaviour {

	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Q))
		{
			transform.position = new Vector3(0,Time.deltaTime,0);
			
		}

		if (Input.GetKey(KeyCode.W))
		{
			//transform.position = new Vector3(Time.deltaTime, 0, 0);(Time.deltaTime, 0, 0);
		}
	}
}
