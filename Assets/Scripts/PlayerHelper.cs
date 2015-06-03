using UnityEngine;
using System.Collections;

public class PlayerHelper : MonoBehaviour {

	void UpdateDamage(float health)
	{
		if(health <= 0)
			WinScreen.Instance.ShowLoseScreen();
	}
}
