using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour 
{
	public GameObject dBox;
	public Text dText;
	public bool dActive;
	public string[] dialogueLines;
	public int currentLine;
	private PlayerController player;
	void Start () 
	{
		player = FindObjectOfType<PlayerController>();
	}
	//En esta parte al presionar la tecla de espacio saldrán los dialogos
	//Cada linea esta guardada en un array que mostrara el texto en el que vayamos
	void Update () 
	{
		if(dActive && Input.GetKeyDown(KeyCode.Space))
		{
			//dBox.SetActive(false);
			//dActive = false;
			currentLine++;
		}
		if(currentLine >= dialogueLines.Length)
		{
			dBox.SetActive(false);
			dActive = false;
			currentLine = 0;
			player.canMove = true;
		}
		dText.text = dialogueLines[currentLine];
	}
	//Al momento de interactuar saldra el dialogo en pantalla
	public void ShowBox(string dialogue)
	{
		dActive = true;
		dBox.SetActive(true);
		dText.text = dialogue;
	}
	//En esta funcion publica vamos a mostrar los dialogos en pantalla apenas interactuemos
	public void ShowDialogue()
	{
		dActive = true;
		dBox.SetActive(true);
		player.canMove = false;
	}
}
