using UnityEngine;
using System.Collections;

public class VFXManger : MonoBehaviour {

	public static VFXManger Instance;

	public GameObject[] effects;


	void Awake () 
	{
		Instance = this;
	}

	public void Spawn(string name, Vector3 postion, Quaternion rotation)
	{
		foreach(GameObject fx in effects)
		{
			if(fx.name == name)
			{
				Instantiate (fx, postion, rotation);
				return;
			}
		}
		Debug.Log ("cannot find effect" + name);
	}
}
