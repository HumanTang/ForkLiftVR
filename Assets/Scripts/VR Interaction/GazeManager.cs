using UnityEngine;
using System.Collections;

public class GazeManager : MonoBehaviour
{
	public float sightlength = 100.0f;
	public GameObject selectedObj;
	
	void FixedUpdate()
	{
		RaycastHit seen;
		Ray raydirection = new Ray(transform.position, transform.forward);
		if (Physics.Raycast(raydirection, out seen, sightlength))
		{
			if (seen.collider.tag == "Load")
			{
				seen.collider.gameObject.GetComponent<GazeHandler>().Explode();
			}
			else if (seen.collider.tag == "UI")
			{
				Debug.Log("Hello");
			}
		}
	}

	
}