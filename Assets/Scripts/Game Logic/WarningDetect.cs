using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningDetect : MonoBehaviour
{
	public ForkliftController forklift;
	public AudioSource WarningVocalHint;
	public AudioClip[] WarningSoundClips;
	public bool Rule1 = false;
	public bool Rule2 = false;
	public bool Rule3 = false;
	public bool Rule4 = false;
	public bool Rule5 = false;
	public bool Rule6 = false;
	[Header("Fallback Object Camera")]
	public GameObject stickyCanvas1_fallback_object;
	public GameObject stickyCanvas2_fallback_object;
	public GameObject stickyCanvas3_fallback_object;
	public GameObject stickyCanvas4_fallback_object;
	public GameObject stickyCanvas5_fallback_object;
	public GameObject stickyCanvas6_fallback_object;
	[Header("VR Camera")]
	public GameObject stickyCanvas1;
	public GameObject stickyCanvas2;
	public GameObject stickyCanvas3;
	public GameObject stickyCanvas4;
	public GameObject stickyCanvas5;
	public GameObject stickyCanvas6;
	public bool Fallback = true;
	public InputManager InputManager;
	[Header("GameRule Debug")]
	public float WrongDirection = 0;
	public float OverSpeed = 0;
	public float RaiseForkTooHigh = 0;
	public float DriveTiltFork = 0;
	public float DriveAdjustForkLR = 0;
	public float DriveRaiseLowFork = 0;
	public float Collision = 0;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Collision = GameRule.collision;
		if (InputManager.isPaused == false) {
			Rule1_check();
			Rule2_check();
			Rule3_check();
			Rule4_check();
			Rule5_check();
			Rule6_check();
			if (Fallback != false)
			{
				stickyCanvas1_fallback_object.SetActive(Rule1);
				stickyCanvas2_fallback_object.SetActive(Rule2);
				stickyCanvas3_fallback_object.SetActive(Rule3);
				stickyCanvas4_fallback_object.SetActive(Rule4);
				stickyCanvas5_fallback_object.SetActive(Rule5);
				stickyCanvas6_fallback_object.SetActive(Rule6);
			}
			else
			{
				stickyCanvas1.SetActive(Rule1);
				stickyCanvas2.SetActive(Rule2);
				stickyCanvas3.SetActive(Rule3);
				stickyCanvas4.SetActive(Rule4);
				stickyCanvas5.SetActive(Rule5);
				stickyCanvas6.SetActive(Rule6);
			}

		}




	}
	void Rule1_check() {
		// watch wrong direction checking
		if (forklift.isWatchingBack == true && ForkliftStatus.Direction == 0 && ForkliftStatus.isDriving == true && ForkliftStatus.Speed > 0)
		{
			Rule1 = true;
			GameRule.WrongDirection += Time.deltaTime;
			WrongDirection = GameRule.WrongDirection;
			WarningVocalHint.clip = WarningSoundClips[0];
			if (WarningVocalHint.isPlaying != true)
			{
				WarningVocalHint.Play();
			}
			
		}
		else if (forklift.isWatchingForward == true && ForkliftStatus.Direction == 1 && ForkliftStatus.isDriving == true && ForkliftStatus.Speed > 0)
		{
			
			Rule1 = true;
			GameRule.WrongDirection += Time.deltaTime;
			WrongDirection = GameRule.WrongDirection;
			WarningVocalHint.clip = WarningSoundClips[0];
			if (WarningVocalHint.isPlaying != true)
			{
				WarningVocalHint.Play();
			}
			
		}
		else
		{
			Rule1 = false;
			
		}
	}
	void Rule2_check()
	{
		// over speed checking
		if (ForkliftStatus.Speed > 8) {
			
			Rule2 = true;
			GameRule.OverSpeed += Time.deltaTime;
			OverSpeed = GameRule.OverSpeed;
			WarningVocalHint.clip = WarningSoundClips[1];
			if (WarningVocalHint.isPlaying != true)
			{
				WarningVocalHint.Play();
			}
		}
		else
		{
			Rule2 = false;
		}
	}

	void Rule3_check() {
		// Raise fork too high while driving
		if (ForkliftStatus.isDriving == true && ForkliftStatus.HeightOfFork > 1.5f && ForkliftStatus.Speed > 0)
		{
			
			GameRule.RaiseForkTooHigh += Time.deltaTime;
			Rule3 = true;
			RaiseForkTooHigh = GameRule.RaiseForkTooHigh;
			WarningVocalHint.clip = WarningSoundClips[2];
			if (WarningVocalHint.isPlaying != true)
			{
				WarningVocalHint.Play();
			}
		}
		else
		{
			Rule3 = false;
		}
	}
	void Rule4_check()
	{
		// tilt fork while driving 
		if (ForkliftStatus.isDriving == true && (Input.GetKey("[2]") || Input.GetKey("[5]"))  && ForkliftStatus.Speed > 0)
		{
			Rule4 = true;
			GameRule.DriveTiltFork += Time.deltaTime;
			DriveTiltFork = GameRule.DriveTiltFork;
			WarningVocalHint.clip = WarningSoundClips[3];
			if (WarningVocalHint.isPlaying != true)
			{
				WarningVocalHint.Play();
			}

		}
		else
		{
			Rule4 = false;
		}

	}
	void Rule5_check()
	{
		// adjust fork while driving 
		if (ForkliftStatus.isDriving == true && (Input.GetKey("[3]") || Input.GetKey("[6]")) && ForkliftStatus.Speed > 0)
		{
			Rule5 = true;
			GameRule.DriveAdjustForkLR += Time.deltaTime;
			DriveAdjustForkLR = GameRule.DriveAdjustForkLR;
			WarningVocalHint.clip = WarningSoundClips[4];
			if (WarningVocalHint.isPlaying != true)
			{
				WarningVocalHint.Play();
			}
		}
		else
		{
			Rule5 = false;
		}
	}
	void Rule6_check()
	{
		// raise fork while driving 
		if (ForkliftStatus.isDriving == true && (Input.GetKey("[1]") || Input.GetKey("[4]")) && ForkliftStatus.Speed > 0)
		{
			Rule6 = true;
			GameRule.DriveRaiseLowFork += Time.deltaTime;
			DriveRaiseLowFork = GameRule.DriveRaiseLowFork;
			WarningVocalHint.clip = WarningSoundClips[5];
			if (WarningVocalHint.isPlaying != true)
			{
				WarningVocalHint.Play();
			}
		}
		else
		{
			Rule6 = false;
		}
	}
}
