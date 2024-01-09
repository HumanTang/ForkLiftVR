using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
	public Button 
		Play_btn,
		Precheck_btn,
		MainMenu_btn,
		Report_btn,
		Exit_btn;
	// Start is called before the first frame update
	void Start()
    {
		Play_btn.onClick.AddListener(Play);
		Precheck_btn.onClick.AddListener(Precheck);
		MainMenu_btn.onClick.AddListener(MainMenu);
		Report_btn.onClick.AddListener(Report);
		Exit_btn.onClick.AddListener(Exit);
	}
	void Play()
	{
		//Output this to console when Button1 or Button3 is clicked
		Debug.Log("You have clicked the Play button!");
		// Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
		SceneManager.LoadScene("Lab", LoadSceneMode.Single);
	}
	void MainMenu()
	{
		//Output this to console when Button1 or Button3 is clicked
		Debug.Log("You have clicked the MainMenu button!");
		// Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
		SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
	}
	void Report()
	{
		//Output this to console when Button1 or Button3 is clicked
		Debug.Log("You have clicked the Report button!");
		// Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
		SceneManager.LoadScene("Game Performance", LoadSceneMode.Single);
	}
	void Exit()
	{
		//Output this to console when Button1 or Button3 is clicked
		Debug.Log("You have clicked the Exit button!");
		// Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
		Application.Quit();
	}
	void Precheck()
	{
		//Output this to console when Button1 or Button3 is clicked
		Debug.Log("You have clicked the Precheck button!");
		// Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
		SceneManager.LoadScene("Precheck Interaction", LoadSceneMode.Single);
	}
	// Update is called once per frame
	void Update()
    {
        
    }
}
