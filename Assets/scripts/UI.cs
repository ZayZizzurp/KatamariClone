using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI : MonoBehaviour
{

	public ballBehavior player;
	
	public Text meterDisplay;
	public Text mmText;
	
	public Image ballSize;
	public SphereCollider katCollider;
	public GameObject katamariBall;
	public float katRadius;

	public GameObject clockHand;


	private float timeLeft = 360 / 20;

	// Use this for initialization
	void Start () {
		//ballSize.rectTransform.localScale = new Vector3(4,4,1);
	}
	
	// Update is called once per frame
	void Update ()
	{
		clockHand.transform.Rotate(0f,0f, -Time.deltaTime * 2.75f);

		
		float radius = (player.bounds.max.x + player.bounds.max.y + player.bounds.max.z) / 3;
		
		ballSize.rectTransform.localScale = new Vector3(radius/2,radius/2,1);
		

		meterDisplay.text = "cm: " +  ((int)radius *2).ToString("F0");
		mmText.text = "mm: " + (radius - (int) radius).ToString("F0");
	}
}
