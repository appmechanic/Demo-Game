using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour {

	GameManager gameMnagerObject;
	ballController playerObject;

	void Awake () 
	{
		gameMnagerObject = GameManager.gameMangerInstance;
		playerObject = ballController.ball_Instance;
	}



	public void OnPlayCalled()
	{
		gameMnagerObject.playPopup.SetActive (false);
		gameMnagerObject.levelPopup.SetActive (true);
	}

	public void OnQuitCalled()
	{
		Time.timeScale = 0;
		Application.Quit ();
	}
	public void OnReplayCalled()
	{
		GameManager.GameLevel = 1;
		GameManager.PlatformCounter = 1;
		GameManager.GameCoins = 0;
		GameManager.GameScore = 0;

		SceneManager.LoadScene (1);
	}
}
