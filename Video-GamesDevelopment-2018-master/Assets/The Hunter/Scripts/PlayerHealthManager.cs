using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour 
{

	public int playerMaxHealth;
	public int playerCurrentHealth;
	private bool flashActive;
	public float flashLength;
	private float countFlashLength;
	private SpriteRenderer playerSpriteRenderer;
	public AudioSource hurt;
	public AudioClip hurtClip;
	void Start () 
	{
		hurt = GetComponent<AudioSource>();
		//Vida inicial del jugador
		playerCurrentHealth = playerMaxHealth;
		playerSpriteRenderer = GetComponent<SpriteRenderer> ();
	}
	void Update () 
	{
		if(playerCurrentHealth <= 0) 
		{
			gameObject.SetActive (false);
		}

		if(flashActive) 
		{
			//Aqui haremos que el jugador parpadee cuando recibe daño
			//Si el contador es mayor a 1.66 segundos el sprite renderer del jugador vuelve a 0
			if(countFlashLength > flashLength * .66f) 
			{
				playerSpriteRenderer.color = new Color (playerSpriteRenderer.color.r, playerSpriteRenderer.color.g, playerSpriteRenderer.color.b, 0.37254902f);
			}
			//Si es mayor a 1.33 segundos vuelve a 1
			else if (countFlashLength > flashLength * .33f) 
			{
				playerSpriteRenderer.color = new Color (playerSpriteRenderer.color.r, playerSpriteRenderer.color.g, playerSpriteRenderer.color.b, 1f);
			}
			else if (countFlashLength > 0f) 
			{
				playerSpriteRenderer.color = new Color (playerSpriteRenderer.color.r, playerSpriteRenderer.color.g, playerSpriteRenderer.color.b, 0.37254902f);
			}
			else 
			{
				//Hace que el sprite rederer del jugador sea visible
				playerSpriteRenderer.color = new Color (playerSpriteRenderer.color.r, playerSpriteRenderer.color.g, playerSpriteRenderer.color.b, 1f);
				flashActive = false;
			}

			countFlashLength -= Time.deltaTime;
		}
	}

	public void HurtPlayer (int damageToGive) 
	{
		//Cuando el jugador toca un enemigo recibe daño
		//Si recibe daño parpadea por unos segundos dandole ese lapso de invunerabilidad
		playerCurrentHealth -= damageToGive;
		hurt.clip = hurtClip;
		hurt.Play();
		flashActive = true;
		countFlashLength = flashLength;
	}
	//aqui le damos la maxima salud al jugador
	public void SetMaxHealth () 
	{
		playerCurrentHealth = playerMaxHealth;
	}
	//Si la vida del jugador llega a 0 el jugador muere
	public void KillPlayer()
	{
		playerCurrentHealth = playerMaxHealth = 0;
	}
}