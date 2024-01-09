using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Zone : MonoBehaviour
{

	public bool finish = false;
	public GameObject forklift_body;
    float _timer = 0f;
    float _duration = 5f;
    public Text Prompt_text;
	public GameObject Prompt_Panel;
	void Awake()
	{
		var MeshCollider = gameObject.GetComponent<MeshCollider>();
	}
    void Tutorial_checking() {
        int length = GameManager.instance.task.Length;
        Debug.Log("length update: " + length);
        if (GameManager.instance.task[length - 2] == true)
        {
            _timer += Time.deltaTime;
            if (_timer >= _duration)
            {
                _timer = 0f;
                XRSettings.enabled = false;               
                SceneManager.LoadScene("GameResult", LoadSceneMode.Single);
            }

           


        }
    }	
    void Lesson1_checking()
    {
        int length = GameManager.instance.task.Length;
        Debug.Log("length update: " + length);
        if (GameManager.instance.GetCurrentStep() == 1 && ForkliftStatus.EngineIsOn == true)
        {
            GameManager.instance.SetTaskFinish();
        }
        else if (GameManager.instance.GetCurrentStep() == 2 && ForkliftStatus.EngineIsOn == false)
        {
            GameManager.instance.SetTaskFinish();
        }
        else if (GameManager.instance.GetCurrentStep() == 3 && ForkliftStatus.EngineIsOn == false && ForkliftStatus.ParkingBrake == true)
        {
            GameManager.instance.SetTaskFinish();
        }
        else if (GameManager.instance.GetCurrentStep() != 3 && GameManager.instance.task[length - 2 ] == true)
        {
            _timer += Time.deltaTime;
            if (_timer >= _duration)
            {
                _timer = 0f;
                XRSettings.enabled = false;        
                SceneManager.LoadScene("GameResult", LoadSceneMode.Single);
            }

           


        }

    }
    void WareHouse_checking()
    {
        Debug.Log("Checking!!");
        int length = GameManager.instance.task.Length;
        Debug.Log("length update: " + length);
        if (GameManager.instance.GetCurrentStep() == 1 && ForkliftStatus.EngineIsOn == true)
        {
            GameManager.instance.SetTaskFinish();
        }
        else if (GameManager.instance.GetCurrentStep() == 2 && ForkliftStatus.EngineIsOn == false)
        {
            GameManager.instance.SetTaskFinish();
        }
        else if (GameManager.instance.GetCurrentStep() == 3 && ForkliftStatus.EngineIsOn == false && ForkliftStatus.ParkingBrake == true)
        {
            GameManager.instance.SetTaskFinish();
        }
        else if (GameManager.instance.GetCurrentStep() != 3 && GameManager.instance.task[length - 2] == true)
        {
            _timer += Time.deltaTime;
            if (_timer >= _duration)
            {
                _timer = 0f;
                XRSettings.enabled = false;
                SceneManager.LoadScene("GameResult", LoadSceneMode.Single);
            }




        }

    }
    void FixedUpdate()
    {
		RaycastHit hit = new RaycastHit();		
		if (Physics.Raycast(transform.position, Vector3.up, out hit))
		{
			var hitter = hit.collider.gameObject.tag;
			if (hitter == "Forklift")
			{
				finish = true;
                if(GameManager.instance.current_lesson == GameManager.Lesson.Tutorial)
                {
                    Tutorial_checking();
                }

                if (GameManager.instance.current_lesson == GameManager.Lesson.Lesson1) {
                    Lesson1_checking();
                }
                if (GameManager.instance.current_lesson == GameManager.Lesson.WareHouse)
                {
                    WareHouse_checking();
                }

            }
			
		}
		else
		{
			finish = false;
		}
	}

	
}

