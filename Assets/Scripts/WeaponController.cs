using UnityEngine;
using System.Collections;

//Script is attatched to the First Person Controller

public class WeaponController : MonoBehaviour 
{
	Weapon currentWeapon;
	int fireTime;
	public GameObject [] weaponArr; //0 - pistol, 1 - rifle, 2 - launcher

	void Awake()
	{
		ChangeWeapon (0);
		Screen.showCursor = false;
	}

	
	// Update is called once per frame
	void Update ()
	{

		//button inputs for weapon switching
		if(Input.GetKeyDown(KeyCode.Alpha1))
	    {
			ChangeWeapon(0); //pistol
		}
		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			ChangeWeapon(1); //rifle
		}
		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			ChangeWeapon(2); //launcher
		}

		if(fireTime > 0)
			fireTime--;

		if(fireTime == 0)
		{
			if (currentWeapon)
			{
				if (Input.GetMouseButton (0)) 
				{
					currentWeapon.Fire ();
					fireTime = currentWeapon.GetCooldown();	
				}
			}
		}
	}

	void ChangeWeapon(short num)
	{
		for(int i = 0; i < weaponArr.Length; i++)
		{
				weaponArr[i].SetActive(false);
		}

		weaponArr[num].SetActive(true);
		currentWeapon = weaponArr[num].GetComponentInChildren<Weapon>();
	}


}
