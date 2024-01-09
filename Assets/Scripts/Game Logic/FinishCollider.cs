using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FinishCollider : MonoBehaviour
{
    public bool enter = false;
    public bool exit = false;
    public bool stay = false;
    public bool front_in = false;
    public bool rear_in = false;
    public bool unload_area;
    public bool transport_area;
    public bool parking_area;
    public GameObject front;
    public GameObject rear;
    public ForkCollision loads;
	public GameObject Prev_Point;
    public GameObject Next_Point;
    
    
    private float stayCount = 0.0f;
    float _timer = 0f;
    float _duration = 5f;
    public Material Material1;
    public Material Material2;
	float time;
	float time_vocal;
	public Text task;
	public string TaskNavigation;
	public string TaskNavigation2;
	public string TaskNavigation3;

	public AudioClip audioClip;
	public AudioClip[] audioClipList;
	public AudioSource audioSource;
	public AudioSource audioSource2;

	public bool isPlayed = false;
	bool played = false;

	public GameObject Fork1;
	public GameObject Fork2;
	public float count = 0;
	// Start is called before the first frame update
	void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

		task.text = TaskNavigation;
		if(loads != null)
		{
			if (loads.isloaded == true && transport_area == true)
			{
				Fork1.gameObject.GetComponent<Renderer>().material = Material1;
				Fork2.gameObject.GetComponent<Renderer>().material = Material1;
				task.text = TaskNavigation2;
				
				audioSource2.clip = audioClipList[0];
				if (audioSource2.isPlaying != true && played == false)
				{
					played = true;
					audioSource2.Play();					
				}
			}
			else if(loads.isloaded == false)
			{
				Fork1.gameObject.GetComponent<Renderer>().material = Material2;
				Fork2.gameObject.GetComponent<Renderer>().material = Material2;
			}
			
		}
			
		

	}

    private void OnTriggerEnter(Collider other)
    {
        enter = true;
        if (enter)
        {
            Debug.Log("Collider entered");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        stay = true;
        if (stay)
        {
        
            var name = other.gameObject.tag;
            if (name == front.tag) {
                front_in = true; 
				

            }
            if (name == rear.tag)
            {
                rear_in = true;
				
			}


        }
       

    }

    private void FixedUpdate()
    {
		//if (unload_area && loads.isloaded == false)
		//{
		//	if (Prev_Point != null)
		//		Prev_Point.SetActive(false);
		//	TaskNavigation = "Go to parking location";

		//}
		if (parking_area == true && loads.isloaded == false && !(rear_in && front_in) )
		{
			TaskNavigation = "Go to parking location";
		}

		if (rear_in && front_in)
        {
			time += Time.fixedDeltaTime;
			time_vocal += Time.fixedDeltaTime;
			Debug.Log("Finish Collider: " + name);
            Debug.Log("time in : " + time);
			
            gameObject.GetComponent<Renderer>().material = Material1;

			if (audioSource != null && audioClip != null)
			{
				audioSource.clip = audioClip;
				
				if (audioSource.isPlaying != true && isPlayed == false) {
					audioSource.Play();
					isPlayed = true;
				}
			}
			if (time >= 1.5f)
			{
				time = 0;
				if(parking_area == false && unload_area == false)
					gameObject.SetActive(false);
				if (unload_area==true) {
					gameObject.GetComponent<FinishCollider>().enabled = false;
					
					
				}
				if (Next_Point != null)
					Next_Point.SetActive(true);
				//if (Prev_Point != null)
				//	Prev_Point.SetActive(false);


			}
			if (time_vocal >= 10f)
			{
				time_vocal = 0;
				isPlayed = false;
			}
			
			if (parking_area == true && loads.isloaded == false) {
				TaskNavigation = "Turn Off engine";
				if (ForkliftStatus.EngineIsOn == false) {
					TaskNavigation = "Set to parking brake";
					if (ForkliftStatus.ParkingBrake == true) {
						
						count += Time.deltaTime;
						TaskNavigation = "Finish";
						if (count >= 2.0f)
						{							
							SceneManager.LoadScene("GameResult");
						}
						
					}
				}
			}
			

			

		}
        else if(!rear_in || !front_in)
		{
			time = 0;
            gameObject.GetComponent<Renderer>().material = Material2;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        exit = true;
        if (exit)
        {
            var name = other.gameObject.tag;
            if (name == front.tag)
            {
                front_in = false;

            }
            if (name == rear.tag)
            {
                rear_in = false;

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
}
