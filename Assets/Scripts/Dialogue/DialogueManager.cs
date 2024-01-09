using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

	public Animator animator;

	private Queue<string> sentences;

	int count = 1;
	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
	}
	void Update()
	{
       
        var square = Input.GetButtonDown("square");
		if (Input.GetKeyDown("l") || true|| square)
		{
            
            if (GameManager.instance.GetTaskFinish()) {
               
                DisplayNextSentence();
                if (GameManager.instance.GetCurrentStep() != GameManager.instance.task.Length) {
                    count++;
                    GameManager.instance.SetCurrentStep(count);
                }
                
			}
			

		}
	}
	public void StartDialogue (Dialogue dialogue)
	{
		animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;

		sentences.Clear();
		// enqueue all string
		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
            
            EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
	}

}
