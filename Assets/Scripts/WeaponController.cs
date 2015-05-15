using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour 
{
	Weapon currentWeapon;

	void Start ()
	{
		currentWeapon = GetComponentInChildren<Weapon> ();
		Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (currentWeapon)
		{
			if (Input.GetMouseButtonDown (0)) 
			{
				currentWeapon.Fire ();
			}
		}
	}
}
