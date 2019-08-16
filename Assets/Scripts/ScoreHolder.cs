using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreHolder : MonoBehaviour {
	[HideInInspector]
	//Current score
	public int score = 0;
	//text to show score while playing the game
	public Text scoreText;
	//text to show final score
	public Text endScoreText;
	//New best ?
	public Text newHightScoreAlert;
	//all the places to show best score at
	public Text[] bestScoreTexts;
	// Use this for initialization
	void Start () {
		if (!scoreText) {
			Debug.LogWarning ("scoreText variable missing");
		}
		score = 0;

		foreach (Text bestScore in bestScoreTexts) {
			if (bestScore)
			bestScore.text = "Best : " + PlayerPrefs.GetInt ("Best", 0).ToString();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!scoreText) {
			return;
		}
		//Show score while playing the game
		scoreText.text = score.ToString();
	}

	void Increment (int value){
		score += value;
	}
	//Set and save the score in all the places
	void EndGame (){
		if (endScoreText)
		endScoreText.text = "Score : "+score.ToString ();
		if (score > PlayerPrefs.GetInt ("Best", 0)) {
			//save the new high score
			PlayerPrefs.SetInt ("Best", score);
			if (newHightScoreAlert)
			newHightScoreAlert.gameObject.SetActive(true);
			foreach (Text bestScore in bestScoreTexts) {
				if (bestScore)
				bestScore.text = "Best : " + PlayerPrefs.GetInt ("Best", 0).ToString();
			}
		}
	}
}
