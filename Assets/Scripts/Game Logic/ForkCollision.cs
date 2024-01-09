using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ForkCollision : MonoBehaviour
{
	
	public Text text;
	public bool isloaded = false;
	
	private void Awake()
	{
		
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
    }

	void OnCollisionEnter(Collision collide)
	{
		
		//var contact = collide.GetContact(0).thisCollider.name;
		//text.text = "1" + "Kg";
	}
	void OnCollisionStay(Collision collide)
	{
		
		var contact = collide.GetContact(0).otherCollider.name;
		if (contact == "Fork")
		{
			var obj = collide.GetContact(0).thisCollider.gameObject.GetComponent<Rigidbody>().mass;
			
			
			isloaded = true;
			text.text = obj.ToString() + "Kg";
			ForkliftStatus.Weighted = true;
		}
		else {
			text.text = "0 Kg";
			isloaded = false;
			ForkliftStatus.Weighted = false;
			
		}
		
	}
	
}
