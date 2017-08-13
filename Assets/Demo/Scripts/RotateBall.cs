using UnityEngine;
using System.Collections;

public class RotateBall : MonoBehaviour {

	// Use this for initialization
	public float rotationSpeed;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GameManager.isGamePlay)
		transform.Rotate (new Vector3(rotationSpeed,0,0));
	}
}
