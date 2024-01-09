using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Arrow : MonoBehaviour
{
	public bool enter = false;
	
	
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
        enter = true;

        if (enter)
		{
			//Debug.Log("entered");
			
			if (other.gameObject.tag == "Forklift" && ForkliftStatus.Direction == 0) {
				//Debug.Log("Dir " + ForkliftStatus.Direction);
				//Destroy(gameObject);
				gameObject.SetActive(false);
                //AngleCheck(other);


			}
		}
	}
    void AngleCheck(Collider other) {
        var car_direction = other.gameObject.transform.right;
        var arrow_direction = this.transform.right;
        float angle = Vector3.Angle(arrow_direction, car_direction);
        //Debug.Log("car_direction"+ car_direction);
        //Debug.Log("arrow_direction"+ arrow_direction);
        //Debug.Log("Angle" + angle);
        if (angle < 15.0f)
        {
            Destroy(gameObject);
            //this.gameObject.SetActive(false);
        }
    }
}
