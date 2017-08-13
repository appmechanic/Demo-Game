using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider g)
	{
		GameManager.gameMangerInstance.onHitObstacle ();
		Destroy (gameObject);
	}
}
