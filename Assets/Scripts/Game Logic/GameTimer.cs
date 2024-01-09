using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
	public float Timer = 0;
	public InputManager InputManager;
	public float elapsed = 0;
    // Start is called before the first frame update
    void Start()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
		if(InputManager.isPaused == false)
		{
			Timer = GameRule.GameTimer;
			GameRule.GameTimer += Time.deltaTime;
		}
		elapsed += Time.deltaTime;
		if (elapsed >= 1f)
		{
			elapsed = elapsed % 1f;
			GameRule.OverAllSpeed += (float)ForkliftStatus.Speed;
		}
	}
}
