using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour 
{
	public float timeToDestroy;	
	void Update () 
	{
		//Destruir el numero de daño que se muestra en pantalla
		timeToDestroy -= Time.deltaTime;

		if (timeToDestroy <= 0)
		{
			Destroy (gameObject);
		}
	}
}
