using UnityEngine;
using System.Collections;

public class EscapeTrigger : MonoBehaviour 
{
	void OnTriggerEnter()
	{
		WinScreen.Instance.ShowWinScreen();
	}

}
