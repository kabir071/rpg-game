using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTalk : MonoBehaviour 
{
	public string dialogue;
	private DialogueManager dMan;
	public string[] dialogueLines;
	//Hacemos un llamado al script que contiene los dialogos
	void Start () 
	{
		dMan = FindObjectOfType<DialogueManager>();	
	}
	//Con un stay haremos que cuando el jugador colisione con un collider
	//El jugador podrá presionar la tecla espacio y un texto salrá en pantalla
	void OnTriggerStay2D (Collider2D col)
	{
		if(col.gameObject.name == "Player")
		{
			if(Input.GetKeyUp(KeyCode.Space))
			{
				//dMan.ShowBox(dialogue);
				//En este if vamos a llamar la funcion de mostrar dialogo que se encuentra en el otro script
				if(!dMan.dActive)
				{
					dMan.dialogueLines = dialogueLines;
					dMan.currentLine = 0;
					dMan.ShowDialogue();
				}
				//Y aqui haremos que al momento de hablar con el NPC este no se mueva hasta que dejemos de hablar
				if(transform.parent.GetComponent<NPCMovement>() != null)
				{
					transform.parent.GetComponent<NPCMovement>().canMove = false;
				}
			}
		}
	}
}
