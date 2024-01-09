using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SteeringWheel : MonoBehaviour
{
	public GameObject steeringWheelTransform;
	public GameObject Accel_Transform;
	public GameObject Brake_Transform;
	public GameObject Lever_Transform;
	public GameObject Lever2_Transform;
	public GameObject BrakeHandle_Transform;	
	public float maxTurnAngle;
	float currentAngle = 0;
	float Accel_currentAngle = 90.0f;
	float Brake_currentAngle = 90.0f;
	float Lever_currentAngle = 90.0f;
	float Lever2_currentAngle = 90.0f;
	public KeyCode lever1;
	public KeyCode lever2;
	public KeyCode lever1_up;
	public KeyCode lever2_up;	
	public bool lever_u;
	public bool lever_d;
	
	void FixedUpdate()
	{

		SteeringWheel_Anim();
		Gas_Pedal();
		Brake_Pedal();
		Lever1();		
		Lever2();
		Gear();
		

	}

	private void SteeringWheel_Anim()
	{
		float rotation = Input.GetAxis("Wheel");

		// This makes your angle somewhere between -30 and 30 degrees
		float targetAngle = Input.GetAxis("Wheel") * maxTurnAngle;
		// This makes the interpolation faster when the input is pressed down,
		// making sure that the value is always positive.
		//float interpolationSpeed = 1 + (Mathf.Abs(Input.GetAxis("Wheel") * 0));
		// This smoothly sets the current angle based on the input
		currentAngle = Mathf.Lerp(currentAngle, targetAngle, 1);
		// replace this with however you implement the final value
		steeringWheelTransform.gameObject.transform.rotation = Quaternion.Euler(180, currentAngle, 0);
		steeringWheelTransform.gameObject.transform.localEulerAngles = new Vector3(0, steeringWheelTransform.gameObject.transform.localEulerAngles.y, 0);
	}

	private void Gear()
	{
		lever_u = Input.GetButtonDown("Lever_Up");
		lever_d = Input.GetButtonDown("Lever_Down");
		if (lever_u)
		{
			if (BrakeHandle_Transform.gameObject.transform.localRotation.x >= -0.8f)
			{
				BrakeHandle_Transform.gameObject.transform.Rotate(-Vector3.right * 30);
                ForkliftStatus.ParkingBrake = false;
            }



		}
		if (lever_d)
		{
			if (BrakeHandle_Transform.gameObject.transform.localRotation.x <= -0.6f)
			{
				BrakeHandle_Transform.gameObject.transform.Rotate(Vector3.right * 30);
              
                ForkliftStatus.ParkingBrake = true;
                Debug.Log("Parking " + ForkliftStatus.ParkingBrake);
               
			}
             

        }
	}

	private void Lever2()
	{
		if (Input.GetKey(lever2))
		{
			//float Lever_targetAngle = 0.3f * 90.0f;
			//Lever_currentAngle = Mathf.Lerp(Lever_currentAngle, Lever_targetAngle, 1);
			//Lever_Transform.gameObject.transform.rotation = Quaternion.Euler(-90 + Lever_currentAngle, 0, 0);
			//Lever_Transform.gameObject.transform.localEulerAngles = new Vector3(Lever_Transform.gameObject.transform.localEulerAngles.x , 0, 0);
			if (Lever2_Transform.gameObject.transform.localRotation.x <= -0.5f)
			{
				Lever2_Transform.gameObject.transform.Rotate(Vector3.right * Time.deltaTime * 25);
			}

		}
		else
		{
			Lever2_currentAngle = 0;
		}

		if (Input.GetKey(lever2_up))
		{
			//float Lever_targetAngle = 0.5f * 90.0f;
			//Lever_currentAngle += Time.deltaTime * Mathf.Lerp(Lever_currentAngle, -Lever_targetAngle, 1);
			//Lever_Transform.gameObject.transform.rotation = Quaternion.Euler(-90 - Lever_currentAngle, 0, 0);

			if (Lever2_Transform.gameObject.transform.localRotation.x >= -0.8f)
			{
				Lever2_Transform.gameObject.transform.Rotate(-Vector3.right * Time.deltaTime * 25);
			}

			//Lever_Transform.gameObject.transform.localEulerAngles = new Vector3(Lever_Transform.gameObject.transform.localEulerAngles.x - Lever_targetAngle * 1.5f, 0, 0);
		}
		else
		{
			Lever2_currentAngle = 0;
		}
	}

	private void Lever1()
	{
		if (Input.GetKey(lever1))
		{
			//float Lever_targetAngle = 0.3f * 90.0f;
			//Lever_currentAngle = Mathf.Lerp(Lever_currentAngle, Lever_targetAngle, 1);
			//Lever_Transform.gameObject.transform.rotation = Quaternion.Euler(-90 + Lever_currentAngle, 0, 0);
			//Lever_Transform.gameObject.transform.localEulerAngles = new Vector3(Lever_Transform.gameObject.transform.localEulerAngles.x , 0, 0);
			if (Lever_Transform.gameObject.transform.localRotation.x <= -0.5f)
			{
				Lever_Transform.gameObject.transform.Rotate(Vector3.right * Time.deltaTime * 25);
			}

		}
		else
		{
			Lever_currentAngle = 0;
		}

		if (Input.GetKey(lever1_up))
		{
			//float Lever_targetAngle = 0.5f * 90.0f;
			//Lever_currentAngle += Time.deltaTime * Mathf.Lerp(Lever_currentAngle, -Lever_targetAngle, 1);
			//Lever_Transform.gameObject.transform.rotation = Quaternion.Euler(-90 - Lever_currentAngle, 0, 0);

			if (Lever_Transform.gameObject.transform.localRotation.x >= -0.8f)
			{
				Lever_Transform.gameObject.transform.Rotate(-Vector3.right * Time.deltaTime * 25);
			}

			//Lever_Transform.gameObject.transform.localEulerAngles = new Vector3(Lever_Transform.gameObject.transform.localEulerAngles.x - Lever_targetAngle * 1.5f, 0, 0);
		}
		else
		{
			Lever_currentAngle = 0;
		}
	}

	private void Brake_Pedal() {
		float AAAA = Input.GetAxis("Accelerator");
		if (AAAA < 0)
		{
			float Brake_targetAngle = Input.GetAxis("Accelerator") * 90.0f;
			Brake_currentAngle = Mathf.Lerp(Brake_currentAngle, -Brake_targetAngle, 1);
			Brake_Transform.gameObject.transform.rotation = Quaternion.Euler(-90 + Brake_currentAngle, 0, 0);
			Brake_Transform.gameObject.transform.localEulerAngles = new Vector3(Brake_Transform.gameObject.transform.localEulerAngles.x + Brake_targetAngle * 1.25f, 0, 0);
		}
	}
	private void Gas_Pedal()
	{
		float AAAA = Input.GetAxis("Accelerator");
		if (AAAA >= 0)
		{
			float Accel_targetAngle = Input.GetAxis("Accelerator") * 90.0f;
			Accel_currentAngle = Mathf.Lerp(Accel_currentAngle, -Accel_targetAngle, 1);
			Accel_Transform.gameObject.transform.rotation = Quaternion.Euler(-90 - Accel_currentAngle, 0, 0);
			Accel_Transform.gameObject.transform.localEulerAngles = new Vector3(Accel_Transform.gameObject.transform.localEulerAngles.x - Accel_targetAngle * 1.25f, 0, 0);
		}
	}

	// Update is called once per frame
	void Update()
    {
		

	}
}
