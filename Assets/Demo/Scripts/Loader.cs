using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour {

	// Use this for initialization
	public Image filler;
	public GameObject levelPopup;
	public Text levelText;
	GameManager gameman;
	void Start () {
		gameman = GameManager.gameMangerInstance;
	}
	
	// Update is called once per frame
	IEnumerator fillImage () 
	{
		while (filler.fillAmount < 1) 
		{
			
			filler.fillAmount += 0.05f;
			//Debug.Log ("fillAmount"+filler.fillAmount);
			yield return new WaitForSeconds (0.1f);

		}
		if(SceneManager.GetActiveScene().name != "Splash")
		{
			yield return new WaitForSeconds (.5f);
			levelText.text = "Level Loaded";
			yield return new WaitForSeconds (1.2f);

			float r = Random.Range (0f, 1f);
			float g = Random.Range (0f, 1f);
			float b = Random.Range (0f, 1f);
			//Debug.Log ("level changed "+r+" "+g+" "+b);
			Color skyColor = new Color (r,g,b,1f);
			Camera.main.backgroundColor = skyColor;
			GameManager.isGamePlay = true;
			gameman.gmLevelText.text = "Level : " + GameManager.GameLevel;
			gameman.platformCounterText.text = "Platform : " + 1;
			GameManager.PlatformCounter = 1;
			levelPopup.SetActive (false);
		}
		else
		{
			SceneManager.LoadScene(1);
		}

	}
	void OnEnable()
	{
		filler.fillAmount = 0;
		StartCoroutine (fillImage());
	}
}
