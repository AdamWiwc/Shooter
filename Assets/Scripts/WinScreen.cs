using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinScreen : MonoBehaviour 
{
	static public WinScreen Instance;
	Text WinText;
	
	void Awake() 
	{
		Instance = this;
		this.gameObject.SetActive (false);
		WinText = GetComponent<Text> ();
		WinText.text = " ";
	}
	
	public void ShowWinScreen()
	{
		this.gameObject.SetActive(true);
		WinText.text = "Freedom! Congratulations you win!";
	}

	public void ShowLoseScreen()
	{
		this.gameObject.SetActive(true);
		WinText.text = "Death! You lose!";
	}
	
}
