using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftController : MonoBehaviour {
	public float maxSteerAngle = 45f;
	public WheelCollider wheelFL;
	public WheelCollider wheelFR;
	public WheelCollider wheelRL;
	public WheelCollider wheelRR;
	public bool isBraking = false;
	public float maxMotorTorque;
	public float maxBrakeTorque;
	public float currentSpeed;
	public float maxSpeed = 10;
	public float accel;
	public float brake;
	public float CurrentMotorTorque;
	public float LiveMotorTorque;
	public float BrakeTorque;
	public float rotation;
	public float angle;
	public bool lever_u;
	public bool lever_d;
	public bool isDriving = false;
	public bool isTurning = false;
	public float direction = 1.0f;
	public Vector3 car_direction;
	public Vector3 face_direction;
	public Vector3 face_direction_fallback_object; // use for debug when no VR headset
	public float angle_fb_obj;
	public GameObject vr_camera;
	public GameObject fallback_vr_camera;
	public bool isWatchingBack = false;
	public bool isWatchingSide = false;
	public bool isWatchingForward = false;
	public bool fallback_obj_mode = false;
	public bool keyboardMode;
	public bool GameControllerMode;
	private void Awake()
	{

		this.GetComponent<Rigidbody>().centerOfMass = new Vector3(0, 0, 0);
		currentSpeed = 0;
		var car_direction = this.transform.forward;

	}
	private void FixedUpdate()
	{
		LiveMotorTorque = wheelFL.motorTorque;
		if (keyboardMode == true)
		{
			Keyboard();
		}
		else
		{
			accel = Input.GetAxis("Accelerator") ;
			brake = Input.GetAxis("Brake") * 1;
			rotation = Input.GetAxis("Wheel");


			FaceDirection();
			Gear();


			if (rotation != 0 && ForkliftStatus.EngineIsOn == true)
			{
				ApplySteer();
				isTurning = true;
			}
			else
			{
				isTurning = false;
			}

			if (ForkliftStatus.EngineIsOn == true && GameManager.instance.current_lesson != GameManager.Lesson.Tutorial)
			{
				Drive();

			}
			
			
			if (accel > 0)
			{
				isBraking = false;
			}
			//if (isDriving == false && isBraking == false && ForkliftStatus.Speed > 0 && accel == 0 || brake == 0)
			//{
			//	BrakeDriving();
			//}

		}
		
	}
	private void FaceDirection() {
		car_direction = this.transform.forward;
		face_direction = vr_camera.transform.forward;
		face_direction_fallback_object = fallback_vr_camera.transform.forward;
		float angle = Vector3.Angle(face_direction, -car_direction);
		angle_fb_obj = Vector3.Angle(face_direction_fallback_object, -car_direction);
		if (fallback_obj_mode == true) {
			angle = angle_fb_obj;
		}
		if (angle > 135)
		{
			isWatchingBack = true;
			isWatchingForward = false;
			isWatchingSide = false;
		}
		else if (angle > 50 && angle < 135)
		{
			isWatchingSide = true;
			isWatchingBack = false;
			isWatchingForward = false;
		}
		else
		{
			isWatchingForward = true;
			isWatchingBack = false;
			isWatchingSide = false;
		}

	}
	private void Gear() {
		lever_u = Input.GetButton("Lever_Up");
		lever_d = Input.GetButton("Lever_Down");
		if (lever_u == true)
		{
			ForkliftStatus.Direction = 0;
			ForkliftStatus.ParkingBrake = false;
			direction = 1.0f;
		}
		else if (lever_d == true)
		{
			ForkliftStatus.Direction = 1;
			ForkliftStatus.ParkingBrake = true;
			direction = -1.0f;
		}
	}
	void GameController(){
		var H = Input.GetAxis("JoystickLeft");
		var V = Input.GetAxis("JoystickRight");
		Debug.Log("H " + H);
		Debug.Log("V " + V);
		accel = V;
		rotation = H;
	}
	void Keyboard() {
		if (Input.GetKeyDown("w") == true && ForkliftStatus.EngineIsOn == true)
		{
			wheelFL.motorTorque = maxMotorTorque * -direction;
			wheelFR.motorTorque = maxMotorTorque * -direction;
			wheelRL.motorTorque = maxMotorTorque * -direction;
			wheelRR.motorTorque = maxMotorTorque * -direction;
			wheelFL.brakeTorque = 0;
			wheelFR.brakeTorque = 0;
			wheelRL.brakeTorque = 0;
			wheelRR.brakeTorque = 0;
			CurrentMotorTorque = wheelRR.motorTorque;
			isDriving = true;
			ForkliftStatus.isDriving = true;
		}
		else
		{
			isDriving = false;
		}
		if (Input.GetKey("a") == true && ForkliftStatus.EngineIsOn == true)
		{
			if (wheelRR.steerAngle <= maxSteerAngle)
			{
				wheelRR.steerAngle += Time.deltaTime * 30;
				wheelRL.steerAngle += Time.deltaTime * 30;
			}

		}
		if (Input.GetKey("d") == true && ForkliftStatus.EngineIsOn == true)
		{
			if (wheelRR.steerAngle >= -maxSteerAngle)
			{
				wheelRR.steerAngle -= Time.deltaTime * 30;
				wheelRL.steerAngle -= Time.deltaTime * 30;
			}

		}
		if (Input.GetKey("s") == true && ForkliftStatus.EngineIsOn == true)
		{
			wheelFL.motorTorque += -Time.deltaTime * 15 * -direction;
			wheelFR.motorTorque += -Time.deltaTime * 15 * -direction;
			wheelRL.motorTorque += -Time.deltaTime * 15 * -direction;
			wheelRR.motorTorque += -Time.deltaTime * 15 * -direction;
			wheelFL.brakeTorque = 0;
			wheelFR.brakeTorque = 0;
			wheelRL.brakeTorque = 0;
			wheelRR.brakeTorque = 0;
			isDriving = true;
			ForkliftStatus.isDriving = isDriving;
		}
		if (Input.GetKey("space") == true && ForkliftStatus.EngineIsOn == true)
		{
			wheelFL.brakeTorque = -Time.deltaTime * maxBrakeTorque;
			wheelFR.brakeTorque = -Time.deltaTime * maxBrakeTorque;
			wheelRL.brakeTorque = -Time.deltaTime * maxBrakeTorque;
			wheelRR.brakeTorque = -Time.deltaTime * maxBrakeTorque;
			wheelFL.motorTorque = 0;
			wheelFR.motorTorque = 0;
			wheelRL.motorTorque = 0;
			wheelRR.motorTorque = 0;
			isBraking = true;
		}

	}
    private void BrakeDriving() {
        wheelFL.brakeTorque = 1 * maxBrakeTorque;
        wheelFR.brakeTorque = 1 * maxBrakeTorque;
        wheelRL.brakeTorque = 1 * maxBrakeTorque;
        wheelRR.brakeTorque = 1 * maxBrakeTorque;

        wheelFL.motorTorque = 0;
        wheelFR.motorTorque = 0;
        wheelRL.motorTorque = 0;
        wheelRR.motorTorque = 0;
    }
	private void Braking()
	{
        CurrentMotorTorque -= 20;
        if (ForkliftStatus.Direction == 0) {

            wheelFL.brakeTorque = -BrakeTorque;
            wheelFR.brakeTorque = -BrakeTorque;
            wheelRL.brakeTorque = -BrakeTorque;
            wheelRR.brakeTorque = -BrakeTorque;

            

        }
        else if (ForkliftStatus.Direction == 1)
        {
            wheelFL.brakeTorque = BrakeTorque;
            wheelFR.brakeTorque = BrakeTorque;
            wheelRL.brakeTorque = BrakeTorque;
            wheelRR.brakeTorque = BrakeTorque;


        }

       

        if (accel == -1) {

            wheelFL.motorTorque = 0;
            wheelFR.motorTorque = 0;
            wheelRL.motorTorque = 0;
            wheelRR.motorTorque = 0;

        }
        isBraking = true;
	}

	private void Drive()
	{
        currentSpeed = 2 * Mathf.PI * wheelFL.radius * wheelFL.rpm * -100 / 1000;
		

		// TODO: change currentSpeed calculation
		//if (ForkliftStatus.Speed < maxSpeed)
		//{
		//      }
		if (accel == 0 && ForkliftStatus.Speed <= 0.1f) // no gas pedal 
		{
			if (ForkliftStatus.Speed == 0) {
				isDriving = false;
				ForkliftStatus.isDriving = isDriving;
			}
		}
			
		if (ForkliftStatus.Speed >= 0.1f)
		{
			isDriving = true;
			ForkliftStatus.isDriving = isDriving;
			if(ForkliftStatus.Direction == 0)
			{
				if (wheelFL.motorTorque < 0)
				{
					var slow = 10;
					Debug.Log("WheelFL " + wheelFL.motorTorque);
					wheelFL.motorTorque += slow;
					wheelFR.motorTorque += slow;
					wheelRL.motorTorque += slow;
					wheelRR.motorTorque += slow;

				}
				
					

			}
			if (ForkliftStatus.Direction == 1)
			{
				if (wheelFL.motorTorque > 0)
				{
					var slow = 10;
					Debug.Log("WheelFL " + wheelFL.motorTorque);
					wheelFL.motorTorque -= slow;
					wheelFR.motorTorque -= slow;
					wheelRL.motorTorque -= slow;
					wheelRR.motorTorque -= slow;

				}
				


			}



		}
		
		
		//if (ForkliftStatus.Direction == 0) {
		//	CurrentMotorTorque = -CurrentMotorTorque;
		//}



		if (accel < 0 )
		{
			BrakeTorque = accel * maxBrakeTorque;
			Braking();
		}

		if( accel > 0)
        {
			CurrentMotorTorque = accel * maxMotorTorque;
			if (ForkliftStatus.Direction == 0) {
				CurrentMotorTorque = -CurrentMotorTorque;
			}
			
			wheelFL.motorTorque = CurrentMotorTorque;
			wheelFR.motorTorque = CurrentMotorTorque;
			wheelRL.motorTorque = CurrentMotorTorque;
			wheelRR.motorTorque = CurrentMotorTorque;




			isDriving = true;
			ForkliftStatus.isDriving = isDriving;
            wheelFL.brakeTorque = 0;
            wheelFR.brakeTorque = 0;
            wheelRL.brakeTorque = 0;
            wheelRR.brakeTorque = 0;
        }

				
	}
	private void ApplySteer()
	{
		
		if (rotation > 0)
		{
			if (wheelRR.steerAngle <= maxSteerAngle)
			{
				//wheelFR.steerAngle = -rotation * maxSteerAngle;
				//wheelFL.steerAngle = -rotation * maxSteerAngle;
				wheelRR.steerAngle = -rotation * maxSteerAngle;
				wheelRL.steerAngle = -rotation * maxSteerAngle;

			}
			
		}
		angle = rotation;
		if (rotation < 0)
		{
			
			if(wheelRL.steerAngle >= -maxSteerAngle)
			{
				//wheelFR.steerAngle = -rotation * maxSteerAngle;
				//wheelFL.steerAngle = -rotation * maxSteerAngle;
				wheelRR.steerAngle = -rotation * maxSteerAngle;
				wheelRL.steerAngle = -rotation * maxSteerAngle;
			}
			
		}
	}
}
