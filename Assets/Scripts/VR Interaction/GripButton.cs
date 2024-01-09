using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		float grip = Input.GetAxis("Grip Left");
		Debug.Log("grip: " + grip);
	}
}
