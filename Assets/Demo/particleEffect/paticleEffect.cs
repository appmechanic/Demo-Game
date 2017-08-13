using UnityEngine;
using System.Collections;

public class paticleEffect : MonoBehaviour {

	// Use this for initialization
	ParticleSystem myParticles;

	void Start () 
	{
		myParticles = GetComponent<ParticleSystem> ();
		myParticles.Emit (100);
		StartCoroutine (destroyObject());
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	IEnumerator destroyObject()
	{
		yield return new WaitForSeconds (myParticles.duration);
		Destroy (gameObject);
	}
}
