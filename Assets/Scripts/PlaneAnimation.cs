using UnityEngine;
using System.Collections;

public class PlaneAnimation : MonoBehaviour {
	//How fast the animation should be played
	public float animationSpeed = 3.0f;
	//animation background ground
	float counter = 0.0f;
	//what's the current sprite
	int currentSprite = 0;
	//all the plane themes
	public enum PlaneTypes
	{
		GreenPlane,RedPlane,YellowPlane,BluePlane
	}
	//current plane theme
	public PlaneTypes planeType;

	//all the sprites based on the plane type
	public Sprite[] greenPlane;
	public Sprite[] redPlane;
	public Sprite[] yellowPlane;
	public Sprite[] bluePlane;
	SpriteRenderer planeRenderer;
	// Use this for initialization
	void Start () {
		//Setting the variables and assigning the plane type
		if (transform.GetComponent<SpriteRenderer> ())
			planeRenderer = transform.GetComponent<SpriteRenderer> ();
		else
			Debug.LogWarning("No SpriteRendere Attached");

		SetPlane (PlayerPrefs.GetString("PlaneColor","Red"));
	}
	
	// Playing the animation
	void Update () {
		if (!planeRenderer) {
			return;
		}

		if (counter <= 0.0f) {
		
			switch (planeType){

			case PlaneTypes.BluePlane : 
				if (bluePlane[currentSprite])
				planeRenderer.sprite = bluePlane[currentSprite];
				currentSprite++;
				if (currentSprite >= bluePlane.Length){
					currentSprite = 0;
				}
				counter = 1.0f;

				break;

			case PlaneTypes.GreenPlane : 
				if (greenPlane[currentSprite])
				planeRenderer.sprite = greenPlane[currentSprite];
				currentSprite++;
				if (currentSprite >= greenPlane.Length){
					currentSprite = 0;
				}
				counter = 1.0f;
				
				break;


			case PlaneTypes.RedPlane : 
				if (redPlane[currentSprite])
				planeRenderer.sprite = redPlane[currentSprite];
				currentSprite++;
				if (currentSprite >= redPlane.Length){
					currentSprite = 0;
				}
				counter = 1.0f;
				
				break;


			case PlaneTypes.YellowPlane : 
				if (yellowPlane[currentSprite])
				planeRenderer.sprite = yellowPlane[currentSprite];
				currentSprite++;
				if (currentSprite >= yellowPlane.Length){
					currentSprite = 0;
				}
				counter = 1.0f;
				
				break;
			}
		
		
		}


		if (counter >= 0.0f) {
			counter -= Time.deltaTime*animationSpeed;
		}
	}

	//sets the theme and saves it
	public void SetPlane (string newType){
		switch (newType) {
		case "Blue": planeType = PlaneTypes.BluePlane;
			PlayerPrefs.SetString("PlaneColor","Blue");
			break;
		case "Red": planeType = PlaneTypes.RedPlane;
			PlayerPrefs.SetString("PlaneColor","Red");
			break;
		case "Green": planeType = PlaneTypes.GreenPlane;
			PlayerPrefs.SetString("PlaneColor","Green");
			break;
		case "Yellow": planeType = PlaneTypes.YellowPlane;
			PlayerPrefs.SetString("PlaneColor","Yellow");
			break;
		}
	}
}
