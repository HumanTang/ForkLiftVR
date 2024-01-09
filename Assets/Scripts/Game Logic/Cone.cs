using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone : MonoBehaviour
{
	Vector3 pos;
	bool fall = false;
	int count = 0;
	// Start is called before the first frame update
	void Start()
    {
		pos = this.gameObject.transform.position;
	}

    // Update is called once per frame
    void Update()
    {
		
		Debug.Log("count:" + GameRule.collision);
	}
	void OnCollisionEnter(Collision collide)
	{
		
		var contact = collide.GetContact(0).otherCollider.tag;
		if (contact == "Forklift" && fall == false)
		{
			
			fall = true;
			GameRule.collision += 1;
            var rigid = gameObject.GetComponent<Rigidbody>();
            //rigid.detectCollisions = false;
            var collider = gameObject.GetComponent<Collider>();
            //collider.isTrigger = true;
            //rigid.isKinematic = true;
            //collider.enabled = false;
        }
		else
		{


		}
		
	}

	

}
