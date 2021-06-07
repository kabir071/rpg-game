using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour 
{
	private QuestManager theQM;
	public int questNumber;
	public bool startQuest;
	public bool endQuest;

	// buscamos el script de questmanager, este será el que almacene las misiones
	//Este script es un activado de misiones al tocar un collider del NPC
	void Start () 
	{
		theQM = FindObjectOfType<QuestManager> ();	
	}
	//En el ontrigger decimos que si el jugador colisiona con el collider
	//La mision empezará mostrando un texto en pantalla haciendo referencia al quest manager
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == "Player") 
		{
			if (!theQM.questCompleted[questNumber]) 
			{
				if (startQuest && !theQM.quests[questNumber].gameObject.activeSelf) 
				{
					theQM.quests [questNumber].gameObject.SetActive (true);
					theQM.quests [questNumber].StartQuest ();
				}

				if (endQuest && !theQM.quests [questNumber].gameObject.activeSelf) 
				{
					theQM.quests [questNumber].EndQuest ();
				}
			}
		}
	}		
}
