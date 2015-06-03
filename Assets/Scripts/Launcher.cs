using UnityEngine;
using System.Collections;

public class Launcher : Weapon 
{
	public Rigidbody Grenade;
	public float force;


	public override void Fire()
	{
		Rigidbody grenadeClone = (Rigidbody) Instantiate(Grenade, muzzleTransform.position, muzzleTransform.rotation);
		grenadeClone.velocity = transform.forward * force;
	}

	public override int GetCooldown()
	{
		return cooldownTime;
	}

}
