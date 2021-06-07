using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingNumbers : MonoBehaviour 
{
	public float moveSpeed;
	public int damageNumber;
	public Text displayNumber;	
	void Update () 
	{
		//A medida que sube de nivel el jugador se mostrará un daño en pantalla a los enemigos y jugador
		displayNumber.text = "" + damageNumber;
		transform.position = new Vector3 (transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);
		
	}
}
