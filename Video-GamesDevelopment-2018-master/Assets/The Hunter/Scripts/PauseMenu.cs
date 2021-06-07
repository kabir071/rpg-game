using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public string mainMenu;
	public bool isPaused;
	public GameObject pausedMenuCanvas;
	//Si se presiona la tecla ESC el juego se pausará y el tiempo del juego se detendrá mientras navegamos en el menu de pausa
	//Si se sale del menu de pausa el juego se resume para continuar jugando
	//Si en el menu de pausa se presiona salir, el juego se cerrará automáticamente
	public void Update ()
	{
		if (this.isPaused) 
		{
			pausedMenuCanvas.SetActive (true);
			Time.timeScale = 0f;
		} 

		else 
		{
			pausedMenuCanvas.SetActive (false);
			Time.timeScale = 1f;
		}
		
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			this.isPaused = !this.isPaused;
		}
	}
	//El booleano se volvera falso y podremos seguir con la partida
	public void Resume ()
	{
		this.isPaused = false;
	}	
	//Al presionar el boton de salir el juego saldrá automáticamente
	public void ExitGame ()
	{
		Application.Quit();
	}
}
