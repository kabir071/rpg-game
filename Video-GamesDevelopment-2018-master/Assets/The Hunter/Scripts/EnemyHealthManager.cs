using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour 
{
	public int enemyMaxHealth;
	public int enemyCurrentHealth;
	private PlayerStats theplayerStats;
	public int expToGive;
	public string enemyQuestName;
	private QuestManager theQM;
	void Start () 
	{
		//Configurando la vida inicial del enemigo y misiones
		enemyCurrentHealth = enemyMaxHealth;
		theplayerStats = FindObjectOfType<PlayerStats> ();
		theQM = FindObjectOfType<QuestManager> ();
	}
	void Update () 
	{
		if(enemyCurrentHealth <= 0) 
		{
			theQM.enemyQuest = enemyQuestName;
			Destroy (gameObject);
			//Al destruir el enemigo añade la experiencia al jugador, así subirá de nivel
			//Asi mismo al ser destruido dara un punto a las misiones del juego
			theplayerStats.AddExpirience (expToGive);
		}
	}

	public void HurtEnemy(int damageToGive) 
	{
		//Cuando el jugador toca el enemigo este sufrirá daño
		enemyCurrentHealth -= damageToGive;
	}
	//Aqui le damos la maxima salud al enemigo
	public void SetMaxHealth () 
	{
		enemyCurrentHealth = enemyMaxHealth;
	}
}
