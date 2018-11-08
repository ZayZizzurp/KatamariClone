using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class LastObjectDisplay : MonoBehaviour
{

	public GameObject objectSpawner;
	public GameObject cube;
	public GameObject cylinder;
	public GameObject plane;
	public GameObject cubePrefab;
	public GameObject currentObject;

	public Text lastObjectText;

	public bool displayEmpty;

	private float rotateSpeed = 25f;
	
	
	
	

	// Use this for initialization
	void Start ()
	{
		displayEmpty = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
		if (displayEmpty == false)
		{
			currentObject.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
		}

		if (Input.GetKeyDown(KeyCode.Q))
		{
			WipeList();
			lastObjectText.text = "Cube";
			cube.gameObject.SetActive(true);
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			WipeList();
			lastObjectText.text = "Cylinder";
			cylinder.gameObject.SetActive(true);
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			WipeList();
			lastObjectText.text = "Plane";
			plane.gameObject.SetActive(true);
		}
	}

	public void WipeList()
	{
		lastObjectText.text = " ";
		cube.gameObject.SetActive(false);
		cylinder.gameObject.SetActive(false);
		plane.gameObject.SetActive(false);
	}
}
