using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
	Scene scene;
	[Header("XR Setting")]
	public GameObject[] XRGameObjects;
	public bool enableXR;
	public GameObject stationary_cam;
	public GameObject Player;


	// Start is called before the first frame update
	void Awake()
    {
		enableXR = true;
		
		
	}
    void Start()
    {
        XRSettings.enabled = enableXR;
        //InputTracking.Recenter();

        foreach (var go in XRGameObjects)
        {
            go.SetActive(enableXR);
        }
    }

    // Update is called once per frame
    void Update()
    {
		if (GameManager.instance.current_stage == GameManager.GameStage.Play)
		{
			SwitchVR();
		}
		
	}

	void SwitchVR()
	{
		var circle = Input.GetButtonDown("circle");
		if (circle == true || Input.GetKeyDown("o"))
		{

			enableXR = !enableXR;
			XRSettings.enabled = enableXR;
		}


		if (enableXR == true)
		{
			stationary_cam.SetActive(!enableXR);
			foreach (var go in XRGameObjects)
			{
				go.SetActive(enableXR);
			}

		}
		else
		{
			stationary_cam.SetActive(!enableXR);
			foreach (var go in XRGameObjects)
			{
				go.SetActive(enableXR);
			}

		}
	}
}
