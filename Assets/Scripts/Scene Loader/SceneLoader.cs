using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{

	public void OnButton(int lesson)
	{
		Debug.Log("Button was pressed!");
        if(lesson == 0)
		    SceneManager.LoadScene("Stage1", LoadSceneMode.Single);
        if (lesson == 1)
            SceneManager.LoadScene("Lesson1", LoadSceneMode.Single);
        if (lesson == 2)
            SceneManager.LoadScene("Lesson2", LoadSceneMode.Single);
        if (lesson == 3)
            SceneManager.LoadScene("Lesson3", LoadSceneMode.Single);   
        if (lesson == 4)
            SceneManager.LoadScene("Lesson4", LoadSceneMode.Single);
		if (lesson == 5)
			SceneManager.LoadScene("WareHouse", LoadSceneMode.Single);
		if (lesson == 6)
			SceneManager.LoadScene("Scoreboard", LoadSceneMode.Single);

	}
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
