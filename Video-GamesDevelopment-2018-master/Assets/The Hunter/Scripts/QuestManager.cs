using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour 
{
	public QuestObject[] quests;
	public bool[] questCompleted;
	public DialogueManager theDM;
	public string enemyQuest;
	//Si la misión se completa se activará un booleano indicando que ha sido completada
	//asi mismo saldra el texto en pantalla diciendolo
	void Start () 
	{
		questCompleted = new bool [quests.Length];
	}
	//por medio de un string en el inspector vamos a declarar el tipo de mision
	public void ShowQuestText(string questText)
	{
		theDM.dialogueLines = new string[1];
		theDM.dialogueLines [0] = questText;
		theDM.currentLine = 0;
		theDM.ShowDialogue ();
	}
}
