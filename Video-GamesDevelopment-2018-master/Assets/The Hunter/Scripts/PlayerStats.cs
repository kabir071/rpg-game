using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour 
{
	public int playerCurrentLevel;
	public int currentExp;
	public int[] toLevelUp;
    public int[] hpLevels;
    public int[] attackLevels;
    public int[] defenseLevels;
    public int currentHP;
    public int currentAttack;
    public int currentDefense;
    private PlayerHealthManager playerHealthManager;
    //Definimos los arrays de los niveles y demas atributos del personaje
	void Start () 
    {
        currentHP = hpLevels[1];
        currentAttack = attackLevels[1];
        currentDefense = defenseLevels[1];
        playerHealthManager = FindObjectOfType<PlayerHealthManager> ();
    }
	void Update () 
    {
		//Si la experiencia es mayor entonces el personaje cumplirá las condiciones para subir de nivel
		if (currentExp >= toLevelUp[playerCurrentLevel]) 
        {
            //playerCurrentLevel++;
            LevelUp();
		}
	}
	//Recibe experiencia cuando se destruye un enemigo
	public void AddExpirience (int expToAdd) 
    {
		currentExp += expToAdd;
	}
	//Cuando el personaje sube de nivel tanto el ataque, defensa y vida se verán afectados
	//Dandole mas vitalidad, fuera y defensa a nuestro personaje y asi sobrevivir mas
    public void LevelUp() 
    {
        playerCurrentLevel++;
        currentHP = hpLevels[playerCurrentLevel];

        playerHealthManager.playerMaxHealth = currentHP;
        playerHealthManager.playerCurrentHealth += currentHP - hpLevels[playerCurrentLevel - 1];

        currentAttack = attackLevels[playerCurrentLevel];
        currentDefense = defenseLevels[playerCurrentLevel];
    }
}
