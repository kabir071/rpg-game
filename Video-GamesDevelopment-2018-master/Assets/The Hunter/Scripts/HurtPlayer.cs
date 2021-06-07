using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour 
{

	public int damageToGive;
	public GameObject damageNumber;
    private int currentDamage;
    private PlayerStats playerstats;
	//Hacemos un llamado al script de las estadisticas del jugador
	void Start () 
	{
        playerstats = FindObjectOfType<PlayerStats>();
    }
	void OnCollisionEnter2D(Collision2D collider) 
	{
        currentDamage = damageToGive - playerstats.currentDefense;
        //Si el daño del jugador es menor a 0 ya no recibirá mas daño
        if(currentDamage < 0) 
		{
            currentDamage = 0;
        }

        //Si los dos colliders tocan al jugador este morirá
        if (collider.gameObject.tag == "Player" && collider.gameObject.name == "Player") 
		{
			collider.gameObject.GetComponent<PlayerHealthManager> ().HurtPlayer (currentDamage);
			//Muestra el numero de daño que ocacionan los enemigos
			var clone = (GameObject)Instantiate(damageNumber, collider.transform.position, Quaternion.Euler(Vector3.zero));
			clone.GetComponent<FloatingNumbers> ().damageNumber = currentDamage;
		}
	}
}
