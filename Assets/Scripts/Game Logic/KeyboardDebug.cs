using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.XR;

public class KeyboardDebug : MonoBehaviour
{
	
	


	[Header("Debug Text")]
	public Text Tilt_angle;	
	public Text Forklift_Speed;
	public Text Fork_Height;
	
	public Text Prompt_text;
	
	public GameObject ground;
	public GameObject Prompt_Panel;
	[Header("Forklift")]	
	public GameObject Forklift;
	public GameObject fork;	
	



	AudioSource Voice_Navigation;
	
	public AudioClip[] VoiceClips;

	
	
	
	public string[] prompt_texts;

	bool fired = false;
	int steps = 0;
	int timepassed = 0;
	bool played = false;
	float triggertime = 0;	
	
	GameObject[] pauseObjects;
	private void Awake()
	{
		Time.timeScale = 1;

	}
	void Update()
    {

		
		HeightOfFork();
		TiltedAngleOfForkToGround();
		SpeedOfForklift();
	
	
		var forkpos = fork.gameObject.transform.position;		
		var planepos = ground.transform.position;
		float distance = Vector3.Distance(forkpos, planepos);
		float dist = (forkpos.y - planepos.y);
		float dist2 = (forkpos - planepos).magnitude;	

	}

	private void PlayInstruction(int task)
	{
		switch (task) {
			case 0:
				
				if (Voice_Navigation.isPlaying != true)
				{
					Prompt_text.text = prompt_texts[steps];
					Voice_Navigation.clip = VoiceClips[steps];
					if (played == false)
					{
						
						Voice_Navigation.Play();
						played = true;
					}
					
					
					steps = task + 1;
					played = false;
				}
				break;
			case 1:
				
				if (Voice_Navigation.isPlaying != true )
				{
					Prompt_text.text = prompt_texts[steps];
					Voice_Navigation.clip = VoiceClips[steps];
					if (played == false) {
						Voice_Navigation.Play();
						played = true;
					}
					
				}
				//if (showmenu == true) {
				//	steps = task + 1;
				//	played = false;
				//}
				
				break;
			case 2:
				
				if (Voice_Navigation.isPlaying != true )
				{
					Prompt_text.text = prompt_texts[steps];
					Voice_Navigation.clip = VoiceClips[steps];
					if (played == false)
					{
						Voice_Navigation.Play();
						played = true;
					}
					


				}
				if (ForkliftStatus.EngineIsOn == true)
				{
					steps = task + 1;
					played = false;
				}
				break;
			
			

		}
	}

	private void SpeedOfForklift()
	{
		var Speed = Forklift.GetComponent<Rigidbody>().velocity.magnitude * 3.6;
		Speed = System.Math.Round(Speed, 1);
		if(GameRule.MaxSpeed <= Speed)
		{
			GameRule.MaxSpeed = (float)Speed;
		}
		ForkliftStatus.Speed = Speed;
		
		if (Speed > 0)
		{
            
            Forklift_Speed.text = Speed.ToString() + " km/h";
		}
		else
		{

			Forklift_Speed.text = Speed.ToString() + " km/h";
		}
	}

	private void TiltedAngleOfForkToGround()
	{
		var tilt = fork.gameObject.GetComponent<BoxCollider>().transform.up;
		var plane = ground.transform.up;
		float angle = Vector3.Angle(tilt, plane);
		angle -= 90.0f;
		angle = -angle;
		angle = (float)System.Math.Round(angle, 2);
        ForkliftStatus.TiltAngle = angle;
		Tilt_angle.text = angle.ToString() + "°";
		
	}

	private void HeightOfFork()
	{
		var forkpos2 = fork.gameObject.transform.position;
		var center = fork.gameObject.GetComponent<BoxCollider>().center.y;
		//Debug.Log("forkpos2: " + forkpos2);
		
		RaycastHit hit = new RaycastHit();
		if (Physics.Raycast(forkpos2, -Vector3.up, out hit))
		{
			var distanceToGround = hit.distance - 0.55f;
			
			distanceToGround = (float)System.Math.Round(distanceToGround, 2) ;
			//gameManager.RaiseDrive(distanceToGround);
			ForkliftStatus.HeightOfFork = distanceToGround;
			GameManager.instance.RaiseDriveTooHigh();
			Fork_Height.text = distanceToGround.ToString() + " m";
		}
		
	}

	private void WeightLoaded()
	{
		throw new NotImplementedException();
	}

	//shows objects with ShowOnPause tag
	public void showPaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnPause tag
	public void hidePaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(false);
		}
	}

}
