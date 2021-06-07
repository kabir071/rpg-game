using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour 
{
	private PlayerController thePlayer;
	private CameraController theCamera;
	public Vector2 startDirection;
	public string pointName;
	void Start ()
	{
		//Encontrar un objeto que el jugador tenga en este caso la movilidad del personaje
		thePlayer = FindObjectOfType<PlayerController> ();

		if (thePlayer.startPoint == pointName) 
		{		
			//Aqui hacemos que el jugador inicie donde esté un punto de inicio
			thePlayer.transform.position = transform.position;
			//La ultima posiicion del jugador
			thePlayer.lastMovement = startDirection;
			//Aqui aplicamos lo mismo pero con el script de la camara
			theCamera = FindObjectOfType<CameraController> ();
			theCamera.transform.position = new Vector3 (transform.position.x, transform.position.y, theCamera.transform.position.z);
		}
	}
}
