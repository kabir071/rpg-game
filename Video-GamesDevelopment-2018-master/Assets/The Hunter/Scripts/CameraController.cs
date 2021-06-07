using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour 
{
	public GameObject followTarget;
	private Vector3 targetPosition;
	public float moveSpeed;
	private static bool cameraExists;
	void Start () 
	{
		if (!cameraExists) 
		{
			cameraExists = true;
			//No destruir el objeto cuando la escena cargue
			DontDestroyOnLoad (transform.gameObject);
		}
		else 
		{
			Destroy (gameObject);
		}
		
	}
	void Update () 
	{
		//posicion de la camara
		targetPosition = new Vector3 (followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
		//la camara seguira al jugador a donde se desplaze
		transform.position = Vector3.Lerp (transform.position, targetPosition, moveSpeed * Time.deltaTime);
	}
}
