using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public static int score;
	public Text text;
	//Aqui haremos que se añadan los puntos al destruir un enemigo
	public static void AddPoints (int pointsToAdd)
	{
		ScoreManager.score += pointsToAdd;
		PlayerPrefs.SetInt ("CurrentPlayerScore", ScoreManager.score);
	}
	//Aqui se reiniciaran al iniciar un nuevo juego
	public static void Reset ()
	{
		ScoreManager.score = 0;
		PlayerPrefs.SetInt ("CurrentPlayerScore", ScoreManager.score);
	}
	//Se llama al componente del texto para que empieze en 0
	void Start ()
	{
		this.text = GetComponent<Text> ();
		//ScoreManager.score = 0;
		ScoreManager.score = PlayerPrefs.GetInt ("CurrentPlayerScore");
	}
	//Aqui haremos que vaya sumando la puntuacion
	void Update ()
	{
		if (ScoreManager.score < 0) 
		{
			ScoreManager.score = 0;
			PlayerPrefs.SetInt ("CurrentPlayerScore", ScoreManager.score);
		}

		this.text.text = "" + ScoreManager.score;
	}
	//Si acá los enemigos son golpeados o destruidos darán una cantidad de puntos
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Ghost")
		{
			score++;
			Destroy(gameObject);
		}

		if(col.gameObject.tag == "Slime")
		{
			score++;
			Destroy(gameObject);
		}
	}
}
