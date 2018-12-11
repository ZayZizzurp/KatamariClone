using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class LastObjectDisplay : MonoBehaviour
{
	public ballBehavior bb;
	public GameObject chesnut;
	public GameObject thumbtack;
	public GameObject match;
	public GameObject caramel;
	public GameObject curDisplay;
	public GameObject candy;
	public GameObject cherries;
	public GameObject cookie;
	public GameObject fu;
	public GameObject pushPin1;

	public Text lastObjectText;

	public bool displayEmpty;

	public Transform camera;

	private float rotateSpeed = 25f;
	
	
	
	

	// Use this for initialization
	void Start ()
	{
		displayEmpty = true;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
		/*if (displayEmpty == false)
		{
			currentObject.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
		}*/
		transform.Rotate(Vector3.up * Time.deltaTime * 60);

	}

	public void WipeList()
	{
		//lastObjectText.text = " ";
		chesnut.gameObject.SetActive(false);
		thumbtack.gameObject.SetActive(false);
		match.gameObject.SetActive(false);
		caramel.gameObject.SetActive(false);
	}

	

	public void DisplayObject(GameObject x)
	{
		if (curDisplay != null)
		{
			Destroy(curDisplay.gameObject);
		}

		curDisplay = (GameObject) Instantiate(x.gameObject);
		curDisplay.transform.parent = transform;
		curDisplay.transform.localScale = new Vector3(.62f,.62f,.62f);
		curDisplay.transform.localPosition = Vector3.zero;
			//(transform.position - camera.transform.position);
		curDisplay.transform.eulerAngles =  transform.eulerAngles;
		curDisplay.GetComponent<Rigidbody>().isKinematic = true;
		

		//curDisplay.GetComponent<Rigidbody>()






		if (x.gameObject.name.Contains("Caramel"))
		{
			lastObjectText.text = "Caramel";
		}

		if (x.gameObject.name.Contains("chestnut"))
		{
			lastObjectText.text = "Chestnut";
		}
		if (x.gameObject.name.Contains("Thumbtack"))
		{

			lastObjectText.text = "Thumbtack";
		}
		
		if (x.gameObject.name.Contains("Match"))
		{
			lastObjectText.text = "Match";
			curDisplay.transform.localScale = new Vector3(.38f,.38f,.38f);
			curDisplay.transform.localPosition = new Vector3(0, -0.01f,0);
		}

		if (x.gameObject.name.Contains("HeadScrew"))
		{
			lastObjectText.text = "Phillips Head Screw";
			curDisplay.transform.localScale = new Vector3(.42f,.42f,.42f);
			curDisplay.transform.localPosition = new Vector3(0, -0.004f,0);
		}
		
		if (x.gameObject.name.Contains("dice"))
		{
			lastObjectText.text = "Dice";
		}
		
		if (x.gameObject.name.Contains("Short Screw"))
		{
			lastObjectText.text = "Short Screw";
			curDisplay.transform.localPosition = new Vector3(0, 0.009f,0);
		}
		
		if (x.gameObject.name.Contains("Candy"))
		{
			lastObjectText.text = "Candy";
		}

		if (x.gameObject.name.Contains("Cherries"))
		{
			lastObjectText.text = "Cherries";
			curDisplay.transform.localScale = new Vector3(.36f,.36f,.36f);
			curDisplay.transform.localPosition = new Vector3(0, -0.004f,0);
		}
		
		if (x.gameObject.name.Contains("Push Pin 1"))
		{
			lastObjectText.text = "Push Pin";
			curDisplay.transform.localScale = new Vector3(.5f,.5f,.5f);
			curDisplay.transform.localPosition = new Vector3(0, -0.015f,0);
		}
		
		if (x.gameObject.name.Contains("Fu"))
		{
			lastObjectText.text = "Fu";
		}
		
		if (x.gameObject.name.Contains("Cookie"))
		{
			lastObjectText.text = "Cookie";
		}
	}
}
