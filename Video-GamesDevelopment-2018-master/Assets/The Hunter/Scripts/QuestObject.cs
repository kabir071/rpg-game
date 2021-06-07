using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour 
{
	public int questNumber;
	public QuestManager theQM;
	public string startText;
	public string endText;
	public bool isEnemyQuest;
	public string targetEnemy;
	public int enemiesToKill;
	private int enemyCount;
	// En el update vamos a realizar el procedimiento para crear las quest de cacería
	//Así mismo que cuente la cantidad de enemigos que llevamos y así culminar la misión
	void Update () 
	{
		if (isEnemyQuest) 
		{
			if (theQM.enemyQuest == targetEnemy) 
			{
				theQM.enemyQuest = null;
				enemyCount++;
			}

			if (enemyCount >= enemiesToKill) 
			{
				EndQuest ();
			}
		}
	}
	//Al iniciar la misión por medio de un trigger saldrá un texto en pantalla indicando el objetivo
	public void StartQuest()
	{
		theQM.ShowQuestText(startText);
	}
	//Al finalizar la misión dirá que la misión fue un éxito
	public void EndQuest()
	{
		theQM.ShowQuestText(endText);
		theQM.questCompleted[questNumber] = true;
		gameObject.SetActive(false);
	}
}
