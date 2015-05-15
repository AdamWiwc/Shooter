using UnityEngine;
using System.Collections;

public class Pistol : Weapon
{
	public override void Fire()
	{
		Transform cameraTransform = Camera.main.transform;
		Ray ray = new Ray (cameraTransform.position, cameraTransform.forward);

		RaycastHit hitInfo = new RaycastHit ();

		if (Physics.Raycast (ray, out hitInfo, range))
		{
			//it hit
			Health health = hitInfo.collider.GetComponent<Health>();


			if(health)
			{
				hitInfo.rigidbody.AddExplosionForce(100f, hitInfo.point, 1f);
				health.TakeDamage(damage);//
			}

		}
	}
}
