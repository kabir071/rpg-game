using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public string startLevel;
	public int playerHealth;
	//Decimos que el juego va a iniciar con una puntuación de cero, maxima vida y la sangre de esa maxima vida
	public void NewGame ()
	{
		PlayerPrefs.SetInt ("CurrentPlayerScore", 0);
		PlayerPrefs.SetInt ("PlayerCurrentHealth", this.playerHealth);
		PlayerPrefs.SetInt ("PlayerMaxHealth", this.playerHealth);
		SceneManager.LoadScene (this.startLevel);
	}
	//Si presionamos el icono de salir el juego se cierra automaticamente
	public void QuitGame ()
	{
		Application.Quit ();
	}
}
