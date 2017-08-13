using UnityEngine;
using System.Collections;

public class PlatformMover : MonoBehaviour {

	// Use this for initialization
	float movingSpeed = 1f;
	GameManager gamemanagerObject;
	public Vector3 resetPoint;
	public GameManager.platformTypes myType;

	void Start () 
	{
		gamemanagerObject = GameManager.gameMangerInstance;
		resetPoint = transform.position;
		OnReset ();

	}
	
	// Update is called once per frame
//	void Update () 
//	{
//		if (GameManager.isGamePlay) 
//		{
//			Vector3 pos = new Vector3 (transform.position.x,transform.position.y,transform.position.z-movingSpeed);
//
//			transform.position = pos;
//
//			if(transform.position.z <= -32)
//			{
//				GameManager.PlatformCounter++;
//				GameManager.gameMangerInstance.setPlatformCounter ();
//
//				transform.position = new Vector3 (transform.position.x,transform.position.y,transform.position.z+250); //resetPoint;
//
//				if (GameManager.PlatformCounter % 15 == 0) 
//				{
//					GameManager.gameMangerInstance.setLevel ();
//					GameManager.gameMangerInstance.resetPlatforms ();
//				}
//			}
//		}
	
//	}

	public void OnReset()
	{
		int random = Random.Range (1,15);
		if(random <= 5)
		{
			myType = GameManager.platformTypes.None;
		}
		else if(random <= 10)
		{
			myType = GameManager.platformTypes.Coins;
		}
		else if(random <= 15)
		{
			myType = GameManager.platformTypes.Obstacle;
		}

		Debug.Log (myType);

		switch (myType) 
		{
		case GameManager.platformTypes.Coins:
			GameObject coin = Instantiate (gamemanagerObject.coinsPrefab, transform.position,Quaternion.identity) as GameObject;
			break;

		case GameManager.platformTypes.Obstacle:
			GameObject Obstacle = Instantiate (gamemanagerObject.ObstaclePrefab, transform.position,Quaternion.identity) as GameObject;
			break;

		}
	}

}
