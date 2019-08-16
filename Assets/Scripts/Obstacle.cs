using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	//bu puan tutucu
	GameObject scoreHolder;
	//mevcut tema
	LevelTheme myTheame;
	//sesi oynatmak için ana kameraya bağlı ses kaynağını alır
	AudioSource myAudio;
	//engel geçerken hangi ses çalmalıdır
	public AudioClip crossingSFX;
	//temada kullanılan sprite'lar
	public Sprite brownGround,brownGroundWithGrass,brownGroundWithSnow,snow,rock;

	// Başlangıçta çalışacak blok
	void Start () {
		//Tüm değişkenleri atama ve temayı temel alan sprite atamak için atama işlevini çağırmak

		if (GameObject.FindObjectOfType<ScoreHolder> ()) {
			scoreHolder = GameObject.FindObjectOfType<ScoreHolder> ().gameObject;
		} else {
			Debug.LogWarning("Score Holder Not found");
		}

		if (GameObject.FindObjectOfType<LevelTheme> ()) {
			myTheame = GameObject.FindObjectOfType<LevelTheme> ();
			AssignGraphic ();
		} else {
			Debug.LogWarning("LevelTheme Not found");
		}

		if (Camera.main.GetComponent<AudioSource> ()) {
			myAudio = Camera.main.GetComponent<AudioSource> ();
		}
	}
	//Assigns the sprites based on the theme
	void AssignGraphic (){
		if (!brownGround || !brownGroundWithGrass || !brownGroundWithSnow || !snow || !rock) {
			Debug.LogWarning("Some variables missing");
			return;
		}

		SpriteRenderer[] allSprites = transform.GetComponentsInChildren<SpriteRenderer> ();

		foreach (SpriteRenderer currSprite in allSprites) {

			switch (myTheame.currentTheme){
			case LevelTheme.Themes.BrownGround : currSprite.sprite = brownGround; break;
			case LevelTheme.Themes.BrownGroundWithGrass : currSprite.sprite = brownGroundWithGrass; break;
			case LevelTheme.Themes.BrownGroundWithSnow : currSprite.sprite = brownGroundWithSnow; break;
			case LevelTheme.Themes.Snow : currSprite.sprite = snow; break;
			case LevelTheme.Themes.Rock : currSprite.sprite = rock; break;
				
			
			
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//checks if we've passed the obstacle then plays the SFX and increments the score
	void OnTriggerExit2D (Collider2D other){
		if (other.GetComponent<PlaneMovement> () && scoreHolder) {
			scoreHolder.SendMessage("Increment",1,SendMessageOptions.RequireReceiver);
			//if (myAudio && crossingSFX){
			//	myAudio.PlayOneShot(crossingSFX);
			//}
		}

	}
}
