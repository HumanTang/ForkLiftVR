using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
	[Header("Input KeyCode")]
	public KeyCode MainMenu;
	public KeyCode Play;
	public KeyCode Report;
	public KeyCode Exit;
	public KeyCode Horn;
	public KeyCode Gear;
	public KeyCode ForkTransform;
	bool triangle;
	bool circle;
	bool square;
	bool cross;
	bool showmenu = false;
	bool showgamecontrol = false;
	public bool isPaused;
	public GameObject Menu;
	public GameObject GameControl;
	public GameObject MainLoader;
	AudioSource sound;
	public AudioClip[] audioClips;
	float index = 0;
	int count = 0;
	public GameObject pointer;
	public ForkliftController forkliftController;
	public Forklift forklift;
	public CameraController cameraController;
	float temp;
	// Start is called before the first frame update
	void Start()
    {
		temp = pointer.gameObject.GetComponent<RectTransform>().localPosition.y;

	}

    // Update is called once per frame
    void Update()
    {
		GetInput();

	}

	void GetInput() {
		
		triangle = Input.GetButtonDown("triangle");
		square = Input.GetButtonDown("square");
		cross = Input.GetButtonDown("cross");
		circle = Input.GetButtonDown("circle");
		if ((triangle == true || Input.GetKeyDown("t")) && showgamecontrol == false)
		{
			//if(GameManager.instance.current_lesson == GameManager.Lesson.Tutorial && GameManager.instance.GetCurrentStep() == 1) {
			//	GameManager.instance.SetTaskFinish();
			//}


			//PauseMenu
			if (showmenu == false)
			{
				isPaused = true;
				Time.timeScale = 0;
				showmenu = !showmenu;
				Menu.gameObject.SetActive(showmenu);				
						
				//deactive other input 
				forklift.gameObject.GetComponent<Forklift>().enabled = false;
				MainLoader.gameObject.GetComponent<MainLoader>().enabled = false;
				MainLoader.gameObject.GetComponent<AudioSource>().enabled = false;
				forkliftController.gameObject.GetComponent<ForkliftController>().enabled = false;
				//cameraController.gameObject.SetActive(showmenu);


			}
			else if (showmenu == true)
			{
				isPaused = false;
				Time.timeScale = 1;
				showmenu = !showmenu;
				Menu.gameObject.SetActive(showmenu);
				forklift.gameObject.GetComponent<Forklift>().enabled = true;
				MainLoader.gameObject.GetComponent<MainLoader>().enabled = true;
				MainLoader.gameObject.GetComponent<AudioSource>().enabled = true;
				forkliftController.gameObject.GetComponent<ForkliftController>().enabled = true;
				//cameraController.gameObject.SetActive(showmenu);
			}


		}
		if (circle == true && showmenu == true)
		{
			if (count == 0) {
				SceneManager.LoadScene("Start Screen");
			}
			if (count == 1)
			{
				GameManager.instance.Restart();
			}
			if (count == 2) {
				GameControl.gameObject.SetActive(showmenu);
				showgamecontrol = true;
				showmenu = !showmenu;
				Menu.gameObject.SetActive(showmenu);
			}
		}

		

		if (square == true)
		{
			if (showgamecontrol == true) {
				GameControl.gameObject.SetActive(!showgamecontrol);
				showgamecontrol = false;
			}
			//sound.clip = audioClips[0];
			//sound.Play();

		}

		if ((cross == true || Input.GetKeyDown("x")) && showmenu == false)
		{
			GameManager.instance.EngineSwitch();
			if (GameManager.instance.current_lesson == GameManager.Lesson.Tutorial && GameManager.instance.GetCurrentStep() == 1) {
				GameManager.instance.SetTaskFinish();
			}else if (GameManager.instance.current_lesson == GameManager.Lesson.Tutorial && GameManager.instance.GetCurrentStep() == 8)
            {
                GameManager.instance.SetTaskFinish();
            }
        }

		if (Input.GetKey(MainMenu))
		{

			SceneManager.LoadScene("Start Screen", LoadSceneMode.Single);
		}
		if (Input.GetKey(Play))
		{

		}
		if (Input.GetKey(Report))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("GameResult"); //Load scene called Game
		}
		if (Input.GetKey(Gear))
		{

		}
		if (Input.GetKey(Horn))
		{

		}
		if (Input.GetKey(Exit))
		{

		}
		var current_y = pointer.gameObject.GetComponent<RectTransform>().localPosition.y;
		//Debug.Log("y " + current_y);
		current_y = pointer.gameObject.GetComponent<RectTransform>().localPosition.y;
		
		if ((Input.GetKeyDown("q") || square) && showmenu == true)
		{
			index = 1;
			count++;
			var current_x = pointer.gameObject.GetComponent<RectTransform>().localPosition.x;
			
			Debug.Log("x " + current_x);
			Debug.Log("y " + current_y);
			Debug.Log("index " + index);
			
			if (count < 4) {
				pointer.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(current_x, current_y - index * 0.1f, 0);
				
			}
			else
			{
				pointer.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(current_x, temp, 0);
				count = 0;
			}
			
		}

	}
}
