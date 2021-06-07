using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour 
{
	//por medio de un string le vamos a indicar que escena queremos cargar
	public void SwitchScene(string name)
	{
		SceneManager.LoadScene(name);
	}
	//Aquí es donde asignamos las escenas que vamos a usar, en mi caso se usan para los menus del juego
	public void ChangeScene()
	{
		SceneManager.LoadScene("Credits");
		SceneManager.LoadScene("MainMenu");;
		SceneManager.LoadScene("HowToPlay");
		SceneManager.LoadScene("Controls");
		SceneManager.LoadScene("Settings");
		SceneManager.LoadScene("Bestiary");
	}
}
