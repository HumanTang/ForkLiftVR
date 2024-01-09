using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UnloadArea : MonoBehaviour { 


	public bool enter = false;
	public bool exit = false;
	public bool stay = false;
	public bool front_in = false;
	public bool rear_in = false;

	public bool unloaded;
	public GameObject front;
	public GameObject rear;

	public Material Material1;
	public Material Material2;




	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	


	}

	private void OnTriggerEnter(Collider other)
	{
		enter = true;
		if (enter)
		{
			Debug.Log("Collider entered");
		}
	}

	private void OnTriggerStay(Collider other)
	{
		stay = true;
		if (stay)
		{

			var name = other.gameObject.tag;
			if (name == front.tag)
			{
				front_in = true;


			}
			if (name == rear.tag)
			{
				rear_in = true;

			}


		}


	}

	private void FixedUpdate()
	{
		
		if (rear_in && front_in)
		{
			unloaded = true;
			gameObject.GetComponent<Renderer>().material = Material1;

		}
		else
		{
			unloaded = false;
			gameObject.GetComponent<Renderer>().material = Material2;
		}
		
	}
	private void OnTriggerExit(Collider other)
	{
		exit = true;
		if (exit)
		{
			var name = other.gameObject.tag;
			if (name == front.tag)
			{
				front_in = false;

			}
			if (name == rear.tag)
			{
				rear_in = false;

			}
		}
	}


}
