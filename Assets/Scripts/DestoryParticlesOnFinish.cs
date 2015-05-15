using UnityEngine;
using System.Collections;

public class DestoryParticlesOnFinish : MonoBehaviour 
{
	ParticleSystem ps;

	void Start()
	{
		ps = GetComponent<ParticleSystem> ();
	}

	void LateUpdate()
	{
		if(!ps.IsAlive ())
		{
			Destroy(gameObject);
		}
	}
}
