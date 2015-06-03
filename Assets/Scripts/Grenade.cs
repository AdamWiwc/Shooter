using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grenade : MonoBehaviour
{
	public float timer;
	bool boom = false;

	void Start()
	{

	}

	// Update is called once per frame
	void Update () 
	{
		timer--;
		if(timer == 0)
		{
			Debug.Log("Boom");
			VFXManger.Instance.Spawn ("ExplosionParticle ", gameObject.transform.position, gameObject.transform.rotation);
			boom = true;
		}
		if(timer  <= -10)
		{
			Destroy(gameObject);
		}
	
	}


	void OnTriggerStay(Collider other)
	{
		if(boom)
		{
			SendMessageOptions options = SendMessageOptions.DontRequireReceiver;

			other.SendMessageUpwards("TakeDamage", 100f, options);
			other.SendMessage("TakeDamage", 100f, options);
		}
	}



}
