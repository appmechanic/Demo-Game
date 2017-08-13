using UnityEngine;
using System.Collections;

public class ballController : MonoBehaviour {

	// Use this for initialization
	Rigidbody rbody;
	public float jumpForce;
	public float jumpFactor = 10;
	public float moveSpeed = 0.5f;
	bool isGrounded;


	public enum ballAllignment
	{
		Left,
		Center,
		Right
	}

	public ballAllignment myAlignment;
	GameManager gm_object;
	float l_score = 0;
	public static ballController ball_Instance;

	void Awake()
	{
		ball_Instance = this;
	}

	void Start () 
	{
		gm_object = GameManager.gameMangerInstance;
		rbody = GetComponent<Rigidbody> ();
		myAlignment = ballAllignment.Center;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameManager.isGamePlay) 
		{

			l_score += Time.deltaTime;
			GameManager.GameScore = (int)(l_score * moveSpeed*5);
			//Debug.Log ("GameScore " +GameScore);
			gm_object.ScoreText.text = "Score : " + GameManager.GameScore;

			Vector3 pos = new Vector3 (transform.position.x,transform.position.y,transform.position.z+moveSpeed);
			transform.position = pos;

			if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) 
			{
				rbody.AddForce (new Vector3(0,jumpForce*jumpFactor,0));
				isGrounded = false;
			}

			if (Input.GetKeyDown (KeyCode.LeftArrow)) 
			{
				switch (myAlignment) 
				{
				case ballAllignment.Center:
					myAlignment = ballAllignment.Left;

					transform.position = new Vector3 (-3,transform.position.y,transform.position.z);
					break;

				case ballAllignment.Right:
					myAlignment = ballAllignment.Center;
					transform.position = new Vector3 (0,transform.position.y,transform.position.z);
					break;

				}
			}

			if (Input.GetKeyDown (KeyCode.RightArrow)) 
			{
				switch (myAlignment) 
				{
				case ballAllignment.Center:
					myAlignment = ballAllignment.Right;
					transform.position = new Vector3 (3,transform.position.y,transform.position.z);
					break;

				case ballAllignment.Left:
					myAlignment = ballAllignment.Center;
					transform.position = new Vector3 (0,transform.position.y,transform.position.z);
					break;

				}
			}	
		}


	}
	void OnCollisionEnter(Collision g)
	{
		if (g.gameObject.tag == "ground") 
		{
			isGrounded = true;
		}
	}

	void OnTriggerEnter(Collider g)
	{
		if (g.gameObject.name == "Cube") 
		{
			g.transform.parent.position = new Vector3 (0, 0, g.transform.parent.position.z + 250);
			GameManager.PlatformCounter++;
			Debug.Log ("PlatformCounter "+GameManager.PlatformCounter);
			GameManager.gameMangerInstance.setPlatformCounter ();
			g.transform.parent.GetComponent<PlatformMover> ().OnReset();
			//transform.position = new Vector3 (transform.position.x,transform.position.y,transform.position.z+250); //resetPoint;

			if (GameManager.PlatformCounter % 15 == 0) 
			{
				GameManager.gameMangerInstance.setLevel ();
				moveSpeed += 0.5f;
				//GameManager.gameMangerInstance.resetPlatforms ();
			}
		}
	}
}
