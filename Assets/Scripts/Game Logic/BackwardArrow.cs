using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackwardArrow : MonoBehaviour
{
	public bool enter = true;
	public Text state;

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
		if (enter)
		{

            //state.text = other.gameObject.name;
            if (other.gameObject.tag == "Forklift" && ForkliftStatus.Direction == 1)
            {
                //Debug.Log("Dir " + ForkliftStatus.Direction);
                Destroy(gameObject);
                //AngleCheck(other);


            }
        }
	}
    void AngleCheck(Collider other)
    {
        var car_direction = other.gameObject.transform.right;
        var arrow_direction = this.transform.right;
        float angle = Vector3.Angle(arrow_direction, car_direction);
        //Debug.Log("car_direction"+ car_direction);
        //Debug.Log("arrow_direction"+ arrow_direction);
        //Debug.Log("Angle" + angle);
        if (angle > 150.0f)
        {
            Destroy(gameObject);
            //this.gameObject.SetActive(false);
        }
    }

}
