using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour 
{
	public int damageToGive;
	public GameObject damageBurst;
	public Transform hitPoint;
	public GameObject damageNumber;
    private int currentDamage;
    private PlayerStats playerStats;
	//Llamamos el script de las estadisticas del jugador
	void Start () 
	{
        playerStats = FindObjectOfType<PlayerStats>();
    }
	//Si la espada colisiona con un enemigo este se destruirá
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Ghost")
		{
            currentDamage = damageToGive + playerStats.currentAttack;

            //Destroy (collision.gameObject);
            //Aqui le damos una colision  llamando el script de la salud del enemigo
            collision.gameObject.GetComponent<EnemyHealthManager> ().HurtEnemy(currentDamage);
			//Crea unas particulas que mostrarán cuanto pierde el enemigo
			Instantiate (damageBurst, hitPoint.position, hitPoint.rotation);
			//Muestra los numeros de daño
			var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
			clone.GetComponent<FloatingNumbers> ().damageNumber = currentDamage;
		}
		//Aplica lo mismo para el otro enemigo
		if (collision.gameObject.tag == "Slime")
		{
            currentDamage = damageToGive + playerStats.currentAttack;
            //Destroy (collision.gameObject);
            collision.gameObject.GetComponent<EnemyHealthManager> ().HurtEnemy(currentDamage);
			Instantiate (damageBurst, hitPoint.position, hitPoint.rotation);
			var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
			clone.GetComponent<FloatingNumbers> ().damageNumber = currentDamage;
		}

		if (collision.gameObject.tag == "Werewolf")
		{
			currentDamage = damageToGive + playerStats.currentAttack;
			collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage);
			Instantiate (damageBurst, hitPoint.position, hitPoint.rotation);
			var clone = (GameObject)Instantiate(damageNumber, hitPoint.position , Quaternion.Euler(Vector3.zero));
			clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
		}

		if(collision.gameObject.tag == "SuperSlime")
		{
			currentDamage = damageToGive + playerStats.currentAttack;
			collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage);
			Instantiate (damageBurst, hitPoint.position, hitPoint.rotation);
			var clone = (GameObject)Instantiate(damageNumber, hitPoint.position , Quaternion.Euler(Vector3.zero));
			clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
		}
	}
}
