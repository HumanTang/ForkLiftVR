using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;

	void Update()
	{
        if (GameManager.instance.GetCurrentStep() == 0)
        {
            if (Input.GetKeyDown("z") || true)
            {
                GameManager.instance.SetCurrentStep(1);
                TriggerDialogue();

            }
        }

    }
    void Start()
    {
        
    }
    public void TriggerDialogue ()
	{
		

		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}

}
