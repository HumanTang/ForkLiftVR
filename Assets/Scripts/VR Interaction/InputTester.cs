using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR;
using Valve.VR.Extras;

public class InputTester : MonoBehaviour
{
	public SteamVR_Input_Sources LeftInputSource = SteamVR_Input_Sources.LeftHand;
	public SteamVR_Input_Sources RightInputSource = SteamVR_Input_Sources.RightHand;
	public SteamVR_Action_Boolean GripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GripTrigger");
	public SteamVR_Action_Boolean RGripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("RGripTrigger");
	public GameObject laserPointer;
	private Component myLight;
	public Canvas Menu;
	bool flag = false;
	public bool isdebug = false;
	void Start()
	{
		Component myLight = laserPointer.GetComponent<SteamVR_LaserPointer>();
		
	}
	private void Update()
	{
		SteamVR_LaserPointer myLight = GetComponent<SteamVR_LaserPointer>();
		Debug.Log(laserPointer);

		if (isdebug == true)
		{
			Debug.Log("Left Trigger value:" + GripAction.GetStateDown(LeftInputSource).ToString());
		}
		if (GripAction.GetStateDown(LeftInputSource) == true) {
			myLight.enabled = !myLight.enabled;
			myLight.holder.SetActive(flag);
			myLight.pointer.SetActive(flag);
			//laserPointer.SetActive(flag);
			if (flag == false)
			{
				flag = true;
				//myLight.pointer.SetActive(flag);
				
			}
			else {
				flag = false;
				//myLight.pointer.SetActive(flag);
				
			}
				
		}
		if (isdebug == true)
		{
			Debug.Log("Right Trigger value:" + GripAction.GetStateDown(RightInputSource).ToString());
		}
		if (RGripAction.GetStateDown(RightInputSource) == true)
		{
			
			Menu.enabled = !Menu.enabled;


		}
		
			
	}
	




	
}