using UnityEngine;

public class Forklift : MonoBehaviour {	

	Transform fork;
	Transform chainRollers;
	Transform forkMechanism;
	Transform forklift;
	Material chainMat;

	const float forkMaxUp = 2f;
	float forkMaxDown;
	[Header("Input KeyCode")]
	public KeyCode raiseForkKeyCode;
	public KeyCode lowerForkKeyCode;
	public KeyCode bendMechanismIn;
	public KeyCode bendMechanismOut;
	public KeyCode adjustForkLeft;
	public KeyCode adjustForkRight;

	
	
	public GameObject forkcol;
	public GameObject ground;
	public float MaxBendOut;
	public float MaxBendIn;
	float maxFork_LR = 0.3f;
	void Awake()
	{
		
	}
	void Start () {
		//Search children based on MeshFilter components (they all have it)
		foreach (var mf in GetComponentsInChildren<MeshFilter>()) {
			//Find fork
			if (mf.name.Equals ("Fork")) {
				fork = mf.transform;
				forkMaxDown = fork.transform.localPosition.z;
			}
			//Find fork mechanism, when found, store Chain material
			if (mf.name.Equals ("Fork_Mechanism")) {
				forkMechanism = mf.transform;
				Renderer r = mf.GetComponent<Renderer> ();
				foreach (var m in r.materials) {
					if (m.name.Contains ("Chain")) {
						chainMat = m;
					}
				}
			}
			//Rollers
			if (mf.name.Equals ("Chain_Rollers")) {
				chainRollers = mf.transform;
			}
			//forklift
			if (mf.name.Equals("Forklift"))
			{
				forklift = mf.transform;
			}

		}

	}
	void Update()
	{
		
	}
	void FixedUpdate()
	{
		//Move fork up and down on local axis, set offset for chain material, rotate the rollers
		if (Input.GetKey(raiseForkKeyCode) && ForkliftStatus.EngineIsOn == true)
		{
			if (fork.transform.localPosition.z <= forkMaxUp)
			{
				fork.transform.localPosition += Vector3.forward * Time.deltaTime;
				chainMat.mainTextureOffset = new Vector2(chainMat.mainTextureOffset.x - Time.deltaTime, chainMat.mainTextureOffset.y);
				chainRollers.Rotate(Vector3.right * 6);
			}
			else if (fork.transform.localPosition.z > forkMaxUp)
			{
				if (GameManager.instance.current_lesson == GameManager.Lesson.Tutorial && GameManager.instance.GetCurrentStep() == 4)
				{
					GameManager.instance.SetTaskFinish();
				}
			}
			if (ForkliftStatus.isDriving) {
				//GameRule.DriveRaiseLowFork += 1;
			}
		}

		if (Input.GetKey(lowerForkKeyCode) && ForkliftStatus.EngineIsOn == true)
		{
			if (fork.transform.localPosition.z >= forkMaxDown)
			{
				fork.transform.localPosition -= Vector3.forward * Time.deltaTime;
				chainMat.mainTextureOffset = new Vector2(chainMat.mainTextureOffset.x + Time.deltaTime, chainMat.mainTextureOffset.y);
				chainRollers.Rotate(-Vector3.right * 6);
			}
			else if (fork.transform.localPosition.z < forkMaxUp)
			{
				if (GameManager.instance.current_lesson == GameManager.Lesson.Tutorial && GameManager.instance.GetCurrentStep() == 5)
				{
					GameManager.instance.SetTaskFinish();
				}
			}
			if (ForkliftStatus.isDriving)
			{
				//GameRule.DriveRaiseLowFork += 1;
			}
		}
		var tilt = forkcol.gameObject.GetComponent<BoxCollider>().transform.up;
		var plane = ground.transform.up;
		float angle = Vector3.Angle(tilt, plane);
		angle -= 90.0f;
		angle = -angle;
		angle = (float)System.Math.Round(angle, 2);
		//Tilt the mechanism
		if (Input.GetKey(bendMechanismIn) && Input.GetKey(bendMechanismOut) == false && ForkliftStatus.EngineIsOn == true)
		{
			if (forkMechanism.localEulerAngles.x < MaxBendIn && angle < 15.0f)
			{
				forkMechanism.Rotate(Vector3.right * Time.deltaTime * 2);
			}
			else 
			{
				if (GameManager.instance.current_lesson == GameManager.Lesson.Tutorial && GameManager.instance.GetCurrentStep() == 7)
				{
					GameManager.instance.SetTaskFinish();
				}

			}
			if (ForkliftStatus.isDriving)
			{
				//GameRule.DriveTiltFork  += 1;
			}
		}
		if (Input.GetKey(bendMechanismOut) && Input.GetKey(bendMechanismIn)  == false && ForkliftStatus.EngineIsOn == true)
		{
			if (forkMechanism.localEulerAngles.x > MaxBendOut && angle > -4.8f)
			{
				forkMechanism.Rotate(-Vector3.right * Time.deltaTime * 2);
			}
			else
			{
				if (GameManager.instance.current_lesson == GameManager.Lesson.Tutorial && GameManager.instance.GetCurrentStep() == 6)
				{
					GameManager.instance.SetTaskFinish();
				}

			}
			if (ForkliftStatus.isDriving)
			{
				//GameRule.DriveTiltFork += 1;
			}


		}

		if (Input.GetKey(adjustForkLeft) && ForkliftStatus.EngineIsOn == true)
		{


			if (fork.transform.localPosition.x >= -maxFork_LR)
			{

				fork.transform.localPosition -= Vector3.right * Time.deltaTime;
				
					
				
			}
			else if(fork.transform.localPosition.x < maxFork_LR)
			{
				if(GameManager.instance.current_lesson == GameManager.Lesson.Tutorial && GameManager.instance.GetCurrentStep() == 3)
				{
					GameManager.instance.SetTaskFinish();
				}
			}
			if (ForkliftStatus.Speed > 0.1f)
			{
				//GameRule.DriveAdjustForkLR += Time.deltaTime;
			}


		}
		if (Input.GetKey(adjustForkRight) && ForkliftStatus.EngineIsOn == true)
		{
			if (fork.transform.localPosition.x <= maxFork_LR)
			{

				fork.transform.localPosition += Vector3.right * Time.deltaTime;
				
					
				
			}
			else if (fork.transform.localPosition.x > maxFork_LR)
			{
				if (GameManager.instance.current_lesson == GameManager.Lesson.Tutorial && GameManager.instance.GetCurrentStep() == 2) {
					GameManager.instance.SetTaskFinish();
				}
			}
			if(ForkliftStatus.Speed > 0.1f)
			{
				//GameRule.DriveAdjustForkLR += Time.deltaTime;
			}

		}

	}
}
