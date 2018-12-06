using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class LastObjectDisplay : MonoBehaviour
{
	public ballBehavior bb;
	public GameObject objectSpawner;
	public GameObject chesnut;
	public GameObject thumbtack;
	public GameObject match;
	public GameObject caramel;
	public GameObject cubePrefab;
	public GameObject currentObject;
	public GameObject curDisplay;

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
		curDisplay.transform.localScale = new Vector3(6.2f,6.2f,6.2f);
		curDisplay.transform.localPosition = (transform.position - camera.transform.position);
		curDisplay.transform.eulerAngles = new Vector3(0,0,0) + transform.eulerAngles;
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
		}

		if (x.gameObject.name.Contains("HeadScrew"))
		{
			lastObjectText.text = "Phillips Head Screw";
		}
		
		if (x.gameObject.name.Contains("dice"))
		{
			lastObjectText.text = "Dice";
		}
		
		if (x.gameObject.name.Contains("Short Screw"))
		{
			lastObjectText.text = "Short Screw";
		}
	}
}
