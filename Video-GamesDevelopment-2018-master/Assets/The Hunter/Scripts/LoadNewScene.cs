using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour 
{
	public string levelToLoad;

	public string exitPoint;
	private PlayerController thePlayerExit;
	//Al llamar al script del controlador del jugador este al tener un dont destroy on load no desaparecerá
	void Start () 
	{
		thePlayerExit = FindObjectOfType<PlayerController> ();
	}

	//Aqui si el juagdor toca un empty con collision cambiará de escena, aplica lo mismo para salir
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{
			SceneManager.LoadScene (levelToLoad);
			thePlayerExit.startPoint = exitPoint;
		}
	}
}
