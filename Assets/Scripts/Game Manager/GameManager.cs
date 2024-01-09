using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
public class GameManager: MonoBehaviour
{

	public static GameManager instance;
	public enum GameStage { Main, Play, Result, Report };
	public enum Lesson { Tutorial = 0, Lesson1 = 1, Lesson2 = 2, Lesson3 = 3, Lesson4 = 4, Lesson5 = 5, WareHouse = 6 };

	public GameStage current_stage;	
	public Lesson current_lesson;

	public bool[] task;
	public int Current_step;
	public AudioClip audioClip;
	public Scene active_scene;
	public bool isRaiseDriveTooHigh = false;
	public void Restart()
	{
		GameRule.ResetValues();
		ForkliftStatus.ResetValues();		
		SceneManager.LoadScene(active_scene.name);
	}

	public void SetCurrentStep(int step)
	{
		Current_step = step;

	}
	public int GetCurrentStep()
	{
		return Current_step;
	}

	public void SetTaskFinish()
	{
		SoundManager.instance.PlayFinishSound();
		task[Current_step] = true;
	

	}
	public bool GetTaskFinish()
	{
		return task[Current_step];
	}



	void Awake()
	{
		

		//Check if instance already exists
		if (instance == null)

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
		SceneManager.sceneLoaded += OnSceneLoaded;


	}
	void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
	{
		var active_scene = SceneManager.GetActiveScene();
		if (scene.name == "Start Screen")
		{
			Destroy(GameManager.instance);
		}
	}
	void Start()
	{
        instance.SetCurrentStep(0);
        getCurrentScene();
		
	}


	//Update is called every frame.
	void Update()
	{
		getCurrentScene();
		
		Debug.Log("Adjust: "+ GameRule.DriveAdjustForkLR);
		Debug.Log("Driving: "+ ForkliftStatus.isDriving);
        Debug.Log("Task length: " + task.Length);
        Debug.Log("Current: " + current_lesson);
		//Debug.Log("current step: " + Current_step);
		//Debug.Log("current leson: " + current_lesson);
		//Debug.Log("Engine: " + ForkliftStatus.EngineIsOn);

	}


	//public void RaiseDrive(float height)
	//{
		
	//	if (ForkliftStatus.Weighted == true && ForkliftStatus.isDriving == true && ForkliftStatus.HeightOfFork > 1.5f)
	//	{
	//		GameRule.RaiseForkTooHigh += Time.deltaTime;
	//	}
	//}


	public void RaiseDriveTooHigh()
	{
		if (ForkliftStatus.isDriving == true && ForkliftStatus.HeightOfFork > 1.5f && ForkliftStatus.Speed > 0)
		{
			isRaiseDriveTooHigh = true;
			GameRule.RaiseForkTooHigh += Time.deltaTime;
		}
		else
		{
			isRaiseDriveTooHigh = false;
		}
	}

	public void EngineSwitch()
	{
		if (ForkliftStatus.EngineIsOn == true)
		{
			ForkliftStatus.EngineIsOn = false;
		}
		else
		{
			ForkliftStatus.EngineIsOn = true;
		}

	}


	public void ChangeGameStage(GameManager.GameStage stage)
	{
		current_stage = stage;
	}	


	public void PlaySound()
	{
		AudioSource sound = new AudioSource();
		sound.clip = audioClip;
		sound.Play();
	}


	
	void getCurrentScene()
	{
		active_scene = SceneManager.GetActiveScene();
		if (active_scene.name == "Start Screen")
		{
			current_stage = GameStage.Main;
		}
		else if (active_scene.name == "GameResult")
		{
			current_stage = GameStage.Result;
		}
		else if (active_scene.name == "Stage1") {
			current_stage = GameStage.Play;
			current_lesson = Lesson.Tutorial;
		}
		else if (active_scene.name == "Lesson1")
		{
			current_stage = GameStage.Play;
			current_lesson = Lesson.Lesson1;
		}
		else if (active_scene.name == "Lesson2")
		{
			current_stage = GameStage.Play;
			current_lesson = Lesson.Lesson2;
		}
		else if (active_scene.name == "Lesson3")
		{
			current_stage = GameStage.Play;
			current_lesson = Lesson.Lesson3;
		}
		else if (active_scene.name == "Lesson4")
		{
			current_stage = GameStage.Play;
			current_lesson = Lesson.Lesson4;
		}
		else if (active_scene.name == "Lesson5")
		{
			current_stage = GameStage.Play;
			current_lesson = Lesson.Lesson5;
		}
        else if (active_scene.name == "WareHouse")
        {
            current_stage = GameStage.Play;
            current_lesson = Lesson.WareHouse;
        }
    }

}