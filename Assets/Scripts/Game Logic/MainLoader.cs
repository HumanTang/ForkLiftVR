using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Valve.VR.InteractionSystem;
public class MainLoader : MonoBehaviour
{
	public GameManager gameManager;
	public SoundManager soundManager;         //SoundManager prefab to instantiate.
	private GameObject player;	
	public AudioClip[] audioClip;
	int count = 0;
	int myflag = 0;
	
	void Awake()
	{
		GameRule.ResetValues();
		ForkliftStatus.ResetValues();

		

		if (GameManager.instance == null)
		{
			//Instantiate gameManager prefab

			Instantiate(gameManager);
		}
		GameManager.instance.ChangeGameStage(GameManager.GameStage.Play);



		//Check if a SoundManager has already been assigned to static variable GameManager.instance or if it's still null
		if (SoundManager.instance == null)
		{
			//Instantiate SoundManager prefab
			Instantiate(soundManager);

		}


	}
	
	private void Update()
	{
	

		if (ForkliftStatus.EngineIsOn == true)
		{
			this.GetComponent<AudioSource>().enabled = true;
			var sound = this.GetComponent<AudioSource>();
			
			if (sound.isPlaying == false && myflag == 0)
			{
				sound.clip = audioClip[0];
				sound.Play();
				myflag = 1;
			}
			else if(sound.isPlaying == false && myflag == 1)
			{
				sound.clip = audioClip[1];
				sound.Play();
			}
			count = 0;
		}
		else if (ForkliftStatus.EngineIsOn == false)
		{
			var sound = this.GetComponent<AudioSource>();
			sound.clip = audioClip[2];
			if (sound.isPlaying == false && count == 0)
			{
				sound.Play();
				count = 1;
				myflag = 0;
			}
			
		}
		//Debug.Log(gameManager.enCurrent);
		//Debug.Log("in Main scene");

	}
}
