using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UI : MonoBehaviour
{

	public ballBehavior player;
	
	public Text meterDisplay;
	public Text mmText;
	public Text timeDisplay;
	
	public Image ballSize;
	public SphereCollider katCollider;
	public GameObject katamariBall;
	public float katRadius;
	public Image timerHolder;

	public GameObject clockHand;

	public float firstTimer = 120;

	public float timeLeft;
	public float secondTimer;

	public bool orangeTimer;
	public float handSpeed; 


	//private float timeLeft = 360 / 20;

	// Use this for initialization
	void Start () {
		//ballSize.rectTransform.localScale = new Vector3(4,4,1);
		timeLeft = 120;
		handSpeed = 2f;
		secondTimer = 60f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (secondTimer <= 0)
		{
			SceneManager.LoadScene (1);
		} 
		
		timerFunctionality();
		//Debug.Log(Time.realtimeSinceStartup);
		
		//clockHand.transform.Rotate(0f,0f, -Time.deltaTime * 2.75f);
		

		/*if (clockHand.transform.rotation.z <= -270 && clockHand.transform.rotation.z >= -290)
		{
			clockHand.transform.localRotation.z = (0,0,0);
		}*/
		if (timeLeft > 60 && orangeTimer == false)
		{
			timeDisplay.text = "02";
		} else if (timeLeft <= 60 && orangeTimer == false)
		{
			timeDisplay.text = "01";
		}
		else
		{
			timeDisplay.text = secondTimer.ToString("F1");
		}

		//figures out the size of the ball 
		//float radius = (player.bounds.max.x + player.bounds.max.y + player.bounds.max.z) / 6;
		float radius = (player.bounds.size.x + player.bounds.size.y + player.bounds.size.z) / 2;
		// best: float radius = Mathf.Max(Mathf.Max(player.bounds.size.x, player.bounds.size.y),  player.bounds.size.z) * 3;
		//max(max(a,b), c)
		//controls the ba;;'s display size by finding the ball's radius
		ballSize.rectTransform.localScale = new Vector3(radius,radius,1);
		
		Debug.Log("Radius = " + radius);
		meterDisplay.text = "cm: " +  ((int)radius *2).ToString("F0");
		mmText.text = "mm: " +( (radius - (int) radius) * 10).ToString("F0");
	}

	
	
	
	public void timerFunctionality()
	{
		timeLeft -= Time.deltaTime;

		if (timeLeft >= 0 && orangeTimer == false)
		{
			clockHand.transform.Rotate(0f,0f, -Time.deltaTime * 2.75f);
		}
		else
		{
			if (orangeTimer == false)
			{
				clockHand.transform.eulerAngles = new Vector3(0, 0, 90);
			}

			timeLeft = 60;
			orangeTimer = true;
		}

		if (orangeTimer == true)
		{
			clockHand.transform.Rotate(0f,0f, -Time.deltaTime * 5.9f);
			secondTimer -= Time.deltaTime;
			timerHolder.GetComponent<Image>().color = Color.yellow;

			if (secondTimer <= 0)
			{
				Time.timeScale = 0;
			}
		}
		
	}
}
