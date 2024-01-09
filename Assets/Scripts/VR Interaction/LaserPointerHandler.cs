using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;
public class LaserPointerHandler : MonoBehaviour
{
	public SteamVR_LaserPointer laserPointer;
	public GameManager gameManager;
	public Player player;
	public bool selected;
	// Start is called before the first frame update

	void Start()
	{
		laserPointer.PointerIn += PointerInside;
		laserPointer.PointerOut += PointerOutside;
		laserPointer.PointerClick += PointerClickHandler;
		selected = false;
	}
	// Update is called once per frame
	void Update()
	{

	}
	public void PointerInside(object sender, PointerEventArgs e)
	{

		if (this != null)
		{
			if (e.target.name == this.gameObject.name && selected == false)
			{
				selected = true;
				Debug.Log("pointer is inside this object " + e.target.name);
			}
		}
		
	}
	public void PointerClickHandler(object sender, PointerEventArgs e)
	{
		if (this != null)
		{
			if (e.target.name == this.gameObject.name && selected == true)
			{
				selected = true;
				Debug.Log("pointer is clicked to  this object " + e.target.name);
				if (e.target.name == "Play Button") {
					gameManager.current_stage = GameManager.GameStage.Play;
					SceneManager.LoadScene("Stage1", LoadSceneMode.Single);
				}
				
			}
		}
		
	}
	public void PointerOutside(object sender, PointerEventArgs e)
	{
		if (this != null)
		{
			if (e.target.name == this.gameObject.name && selected == true)
			{
				selected = false;
				Debug.Log("pointer is outside this object " + e.target.name);
			}
		}
		
	}
	public bool get_selected_value()
	{
		return selected;
	}
}