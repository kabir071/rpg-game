using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
	public Slider healthBar;
	public Text HPtext;
	public PlayerHealthManager playerHealth;
	private static bool UIExist;
	private PlayerStats thePlayerStats;
	public Text levelText;
	void Start () 
	{
		if(!UIExist) {
			UIExist = true;
			//No destruir el objeto cuando la escena cargue
			DontDestroyOnLoad (transform.gameObject);
		}
		else 
		{
			Destroy (gameObject);
		}
		//Haremos uso de las estadisticas del jugador
		thePlayerStats = GetComponent<PlayerStats> ();
	}
	void Update () 
	{
		//La barra de salud hace referencia al script de vida del personaje
		//Asi mismo al sistema de nveles
		healthBar.maxValue = playerHealth.playerMaxHealth;
		healthBar.value = playerHealth.playerCurrentHealth;
		HPtext.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
		levelText.text = "Level: " + thePlayerStats.playerCurrentLevel;
	}
}
