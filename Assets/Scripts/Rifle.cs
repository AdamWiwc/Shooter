using UnityEngine;
using System.Collections;

public class Rifle : Weapon
{
	public Transform muzzleTransform;
	public float hitForce;


	public override void Fire()
	{
		Transform cameraTransform = Camera.main.transform;

		VFXManger.Instance.Spawn ("muzzleFlair", muzzleTransform.position, muzzleTransform.rotation);

		Ray ray = new Ray (cameraTransform.position, cameraTransform.forward);

		RaycastHit hitInfo = new RaycastHit ();

		if (Physics.Raycast (ray, out hitInfo, range))
		{
			//it hit
			Health health = hitInfo.collider.GetComponent<Health>();


			if(health)
			{
				VFXManger.Instance.Spawn ("bloodSplatter", hitInfo.point, Quaternion.identity);
				hitInfo.rigidbody.AddForceAtPosition(-hitForce * hitInfo.normal, hitInfo.point);
				health.TakeDamage(damage);//
			}
			//for dust use Quaternion rotation = Quaternion.FromToRotation(vector3.forward, hitInfo.normal);
			// VFXManger.Instance.Spawn ("dust", hitInfo.point, rotation);
		}
	}
}
