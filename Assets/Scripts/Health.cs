using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{

	public int maxHealth;

	float health;

	void Start()
	{
		health = maxHealth;
	}

	public void TakeDamage (float amount)
	{
		health = health - amount;
		SendMessage("UpdateDamage", health);
		Debug.Log(health);

	}
}
