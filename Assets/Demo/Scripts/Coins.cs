using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour {

	public float rotationSpeed;
	public GameObject effect;
	void Start () {

	}

	// Update is called once per frame
	void Update () 
	{
		if(GameManager.isGamePlay)
			transform.Rotate (new Vector3(0,rotationSpeed,0));
	}

	void OnTriggerEnter(Collider g)
	{
		GameObject effectobject = Instantiate (effect,transform.position,Quaternion.identity) as GameObject;
		GameManager.gameMangerInstance.setCoins ();
		Destroy (gameObject);
	}
}
