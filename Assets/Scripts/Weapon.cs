using UnityEngine;
using System.Collections;

//Script is not attatched to anything

public abstract class Weapon : MonoBehaviour 
{
	public int damage;
	public float range;
	public float headShotMultiplyer;
	public Transform muzzleTransform;
	public float recoil;
	public int cooldownTime;

	public abstract void Fire();
	public abstract int GetCooldown();

}
