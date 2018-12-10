using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {
	
	public Animator boiAnimator;
	public ballBehavior ball;

	// Use this for initialization
	void Start ()
	{
		boiAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey((KeyCode.RightArrow)) || Input.GetKey((KeyCode.LeftArrow)) || Input.GetKey((KeyCode.A)) ||  Input.GetKey((KeyCode.D)) && (!Input.GetKey(KeyCode.W)))
		{
			boiAnimator.Play("Turning animation");
		}
		else if (Input.GetKey((KeyCode.S)) || Input.GetKey((KeyCode.DownArrow)) && !Input.GetKey((KeyCode.A)) &&  !Input.GetKey((KeyCode.D)) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftArrow)&& !Input.GetKey(KeyCode.DownArrow)&& !Input.GetKey(KeyCode.RightArrow))
		{
			boiAnimator.Play("Backwards animation");
		}
		else
		{
			boiAnimator.Play("Running animation");
		}
	}
}
