using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
	public int BT_size = 30;
	public int LR_size = 30;
	public int top = 150;
	public GameObject barrier_r;
	public GameObject barrier_w;
	public GameObject barrier_r2;
	public GameObject barrier_w2;
	float barrier_size = 1.253f;
	
	bool generate_boundary2(float x = 0, float y = 0, float z = 0)
	{



		for (int i = 0; i < LR_size; i++)
		{
			
			
			if (i % 2 == 0)
			{
				Instantiate(barrier_r2);
				barrier_r2.transform.localPosition = new Vector3(x, y, -barrier_size * i + z);
				barrier_r2.transform.eulerAngles = new Vector3(0, 90, 0);
		//barrier_r2.gameObject.transform.localRotation = new Quaternion(0,0,0,0);
		//barrier_r.AddComponent<Rigidbody>();
		var rigid = barrier_r2.GetComponent<Rigidbody>();
				rigid.isKinematic = true;

			}
			else
			{

				Instantiate(barrier_w2);
				barrier_w2.transform.localPosition = new Vector3(x, y, -barrier_size * i + z);
				barrier_w2.transform.eulerAngles = new Vector3(0, 90, 0);

				//barrier_w2.gameObject.transform.localRotation = new Quaternion(0,0,0,0);
				//barrier_w.AddComponent<Rigidbody>();
				var rigid = barrier_w2.GetComponent<Rigidbody>();
				rigid.isKinematic = true;


			}

		}
		return true;
	}

	bool generate_boundary(float x = 0, float y = 0 , float z = 0)
	{
		for (int i = 0; i < BT_size; i++)
		{

			if (i % 2 == 0)
			{
				Instantiate(barrier_r, new Vector3(-barrier_size * i + x, y, z), Quaternion.identity);
				
				//barrier_r.gameObject.transform.localRotation = new Quaternion();
				//barrier_r.AddComponent<Rigidbody>();
				var rigid = barrier_r.GetComponent<Rigidbody>();
				rigid.isKinematic = true;

			}
			else
			{
				
				Instantiate(barrier_w, new Vector3(-barrier_size * i + x, y, z), Quaternion.identity);				
				//barrier_w.gameObject.transform.localRotation = new Quaternion();
				//barrier_w.AddComponent<Rigidbody>();
				var rigid = barrier_w.GetComponent<Rigidbody>();				
				rigid.isKinematic = true;


			}

		}
		return true;
	}
	void Awake()
	{

				
		
		
		

		
		

	}
	// Start is called before the first frame update
	void Start()
    {


		if(generate_boundary())
		generate_boundary(0, 0, -32);
	
		if(generate_boundary2(0, 0, 0))
		generate_boundary2(-40, 0, 0);

		

	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
