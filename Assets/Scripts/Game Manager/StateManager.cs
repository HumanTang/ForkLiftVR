using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
	public static StateManager instance = null;
	public bool isLoggedIn;

	public void Login(bool login)
	{
		isLoggedIn = login;		

	}
	// Start is called before the first frame update
	void Start()
    {
        
    }
	void Awake()
	{
		if (instance == null)
		{

			//if not, set instance to this
			instance = this;

		}//If instance already exists and it's not this:

		else if (instance != this)
		{

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);
		}






		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	}
	// Update is called once per frame
	void Update()
    {
		Debug.Log("Login:" + isLoggedIn);
	}
}
