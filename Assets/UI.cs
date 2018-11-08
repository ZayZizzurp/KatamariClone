using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI : MonoBehaviour
{

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
		katRadius = katCollider.radius;
		
		clockHand.transform.Rotate(0f,0f, -Time.deltaTime); 
		
		ballSize.rectTransform.localScale = new Vector3(katamariBall.transform.localScale.x/4,katamariBall.transform.localScale.y/4,katamariBall.transform.localScale.z);
	}
}
