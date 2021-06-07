using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeEnemyController : MonoBehaviour 
{
	public float moveSpeed;
	private Rigidbody2D slimeRigidbody;	
	private bool moving;
	public float timeBetweenMove;
	private float timeBetweenMoveCounter;
	public float timeToMove;
	private float timeToMoveCounter;
	private Vector3 moveDirection;
	public float waitToReload;
	private bool reloading;
	private GameObject thePlayer;
	void Start () 
	{
		slimeRigidbody = GetComponent<Rigidbody2D>();

		//timeBetweenMoveCounter = timeBetweenMove;
		//timeToMoveCounter = timeToMove;

		//El contador hará un movimiento aleatorio en el mapa
		timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeToMove * 1.25f);
		
	}
	void Update () 
	{	
		/*
		 * Si el movimiento es veradero este se seteara en falso para calcular el proximo movimiento
		 * y si es falso congelará la velocidad del enemigo para volverlo verdadero otra vez
		 * y calcular la distancia del siguiente movimiento.
		*/

		if(moving) 
		{
			timeToMoveCounter -= Time.deltaTime;
			slimeRigidbody.velocity = moveDirection;

			if (timeToMoveCounter < 0f) 
			{
				moving = false;
				//timeBetweenMoveCounter = timeBetweenMove;
				timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
			}
		}
		else 
		{
			timeBetweenMoveCounter -= Time.deltaTime;
			slimeRigidbody.velocity = Vector2.zero;

			if(timeBetweenMoveCounter < 0f) 
			{
				moving = true;
				//timeToMoveCounter = timeToMove;
				timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeToMove * 1.25f);

				moveDirection = new Vector3(Random.Range(-1.0f, 1.0f) * moveSpeed, Random.Range(-1.0f, 1.0f) * moveSpeed, 0);
			}
		}


		//Si es verdadro se cargará el nivel nuevamente con los enemigos y el jugador
		if(reloading) 
		{
			waitToReload -= Time.deltaTime;
			if(waitToReload < 0) 
			{
				thePlayer.SetActive (true);
			}
		}
		
	}

	//Collision between colliders
		//If the two colliders touch Insta kill
		/*
		if (collider.gameObject.tag == "Player" && collider.gameObject.name == "Player") 
		{
			//Deactivates the player
			collider.gameObject.SetActive (false);
			reloading = true;
			thePlayer = collider.gameObject;
		}*/
}
