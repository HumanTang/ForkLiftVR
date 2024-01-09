using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class DDOL : MonoBehaviour
{
	public void Awake()
	{
		DontDestroyOnLoad(gameObject);
		XRSettings.enabled = false;

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
