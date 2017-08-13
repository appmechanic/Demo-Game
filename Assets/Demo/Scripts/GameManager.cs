using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	public static int PlatformCounter = 1;
	public static int GameLevel = 1;
	public static int GameCoins = 0;
	public static int GameScore = 0;
	public  int LastGameScore = 0;
	public Text platformCounterText;
	public Text gmLevelText;
	public static bool isGamePlay = false;

	public GameObject levelPopup;
	public GameObject GameOverPopup;
	public Text gm_leveltext;
	public Text gm_scoretext;
	public Text gm_cointext;
	public Text CoinsText;
	public Text LevelText;
	public Text ScoreText;
	public Image loaderImage;
	public GameObject[] platforms;
	public float scoreFactor;
	public GameObject coinsPrefab;
	public GameObject ObstaclePrefab;
	public GameObject highscoreObject;
	public GameObject playPopup;
	public static GameManager gameMangerInstance;


	public enum platformTypes{
		Coins,
		Obstacle,
		None
	}

	void Awake()
	{
		gameMangerInstance = this;
	}

	void Start () 
	{
		isGamePlay = false;
		highscoreObject.SetActive (false);

		LevelText.text = "Level " + GameLevel;//PlayerPrefs.GetInt ("level", 0);
		ScoreText.text = "Score : " + GameScore;
		CoinsText.text = "Coins : " + GameCoins;
		platformCounterText.text = "Platform : " + PlatformCounter;

		LastGameScore = PlayerPrefs.GetInt ("score", 0);
		gmLevelText.text = "Level : " + GameLevel;
		LevelText.text = "Level Loading";// + GameLevel;

		playPopup.SetActive (true);
	}
	
	public void setPlatformCounter()
	{
		platformCounterText.text = "Platform : " + PlatformCounter;
	}

	public void setLevel()
	{
		GameLevel++;
		isGamePlay = false;
		LevelText.text = "Play Next Level ";
		PlayerPrefs.SetInt ("level", GameLevel);
		levelPopup.SetActive (true);
		//Debug.Log ("Level counter "+GameManager.GameLevel);
	}

	public void setCoins()
	{
		GameCoins++;
		CoinsText.text = "Coin " + GameCoins;
	}

	public void onHitObstacle()
	{
		isGamePlay = false;
		gm_leveltext.text = GameLevel+"";
		gm_cointext.text = GameCoins+"";
		gm_scoretext.text = GameScore+"";
		int playCount = PlayerPrefs.GetInt ("fTime", 0);
		if (playCount != 0) 
		{
			if (LastGameScore < GameScore) 
			{
				highscoreObject.SetActive (true);
				PlayerPrefs.SetInt ("score", GameScore);
			}
		}
		else
			PlayerPrefs.SetInt ("score", GameScore);
		
		playCount++;
		PlayerPrefs.SetInt ("fTime", playCount);
		GameOverPopup.SetActive (true);
	}
}
