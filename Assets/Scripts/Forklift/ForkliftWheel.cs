using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftWheel : MonoBehaviour {
	public WheelCollider targetWheel;
	// Use this for initialization
	private Vector3 wheelPosition = new Vector3();
	private Quaternion wheelRotation = new Quaternion();

	private void Update()
	{
		targetWheel.GetWorldPose(out wheelPosition, out wheelRotation);
		transform.position = wheelPosition;
		transform.rotation = wheelRotation;
	}
}
