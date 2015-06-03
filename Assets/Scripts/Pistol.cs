using UnityEngine;
using System.Collections;

//Script is Attatched to the Pistol Weapon 

public class Pistol : Weapon
{
	public override void Fire()
	{
		Transform cameraTransform = Camera.main.transform;
		VFXManger.Instance.Spawn ("muzzleFlair", muzzleTransform.position, muzzleTransform.rotation);
		Ray ray = new Ray (cameraTransform.position, cameraTransform.forward);
		RaycastHit hitInfo = new RaycastHit ();


		if (Physics.Raycast (ray, out hitInfo, range))
		{
			//it hit
			Health health = hitInfo.collider.GetComponentInParent<Health>();
			HealthHelper head = hitInfo.collider.GetComponent<HealthHelper>();
			
			if(health)
			{
				Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, hitInfo.normal);
				VFXManger.Instance.Spawn ("bloodSplatter", hitInfo.point, rotation);
				
				float effectiveDamage = damage;
				if(head.isHead)
					effectiveDamage *= headShotMultiplyer; //add defence maybe?
				
				health.TakeDamage(effectiveDamage);
				
			}
			else
			{
				Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, hitInfo.normal);
				VFXManger.Instance.Spawn ("dust", hitInfo.point, rotation);
			}

		}
	}

	public override int GetCooldown()
	{
		return cooldownTime;
	}
	
}
