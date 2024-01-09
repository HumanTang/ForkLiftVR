using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class buttonImageSwitch : MonoBehaviour
{
	public Image btn_icon;
	public Text btn_text;
	public Sprite[] btn_icon_list;
	public string[] btn_text_list;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		var step = GameManager.instance.GetCurrentStep();
		btn_icon.sprite = btn_icon_list[step];
		btn_text.text = btn_text_list[step];
	}
}
