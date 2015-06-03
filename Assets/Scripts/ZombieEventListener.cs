using UnityEngine;
using System.Collections;

public class ZombieEventListener : MonoBehaviour 
{
	public void AttackingFrame()
	{
		SendMessageUpwards("OnAttackEvent");
	}

	public void NewEvent()
	{
		//couldn't figure out how to edit events. Having this stops an error message. 
	}
}
