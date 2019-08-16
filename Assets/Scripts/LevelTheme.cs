using UnityEngine;
using System.Collections;



public class LevelTheme : MonoBehaviour {
	//All the themetypes
	public enum Themes
	{
		BrownGround,BrownGroundWithGrass,BrownGroundWithSnow,Snow,Rock
	}
	//Current Theme
	public Themes currentTheme; 
	//This is to check if the theme was changed
	Themes lastTheme;
	//Parent holding Roof objects sprites
	public GameObject roofParent;
	//Parent holding ground objects sprites
	public GameObject groundParent;
	//All the sprite varibles besed on themes
	public Sprite brownGround,brownGroundWithGrass,brownGroundWithSnow,snow,rock;
	//camera to change background color to match the theme
	public Camera mainCamera;
	//color according to themes
	public Color brownGroundThemeColor;
	public Color snowGroundThemeColor;
	public Color rockGroundThemeColor;
	// Use this for initialization
	void Start () {
		//Select random theme
		Theame (Random.Range (0, 5));
	}

	void ChangeGraphics (){
		//Assigning the sprites and color
		switch (currentTheme) {
		case Themes.BrownGround : 
			for (int i = 0; i < roofParent.transform.childCount;i++){
				roofParent.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = brownGround;
			}

			for (int i = 0; i < groundParent.transform.childCount;i++){
				groundParent.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = brownGround;
			}

			if (mainCamera){
				mainCamera.backgroundColor = brownGroundThemeColor;
			}
			break;


		case Themes.BrownGroundWithGrass : 
			for (int i = 0; i < roofParent.transform.childCount;i++){
				roofParent.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = brownGroundWithGrass;
			}
			
			for (int i = 0; i < groundParent.transform.childCount;i++){
				groundParent.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = brownGroundWithGrass;
			}

			if (mainCamera){
				mainCamera.backgroundColor = brownGroundThemeColor;
			}
			break;

		case Themes.BrownGroundWithSnow : 
			for (int i = 0; i < roofParent.transform.childCount;i++){
				roofParent.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = brownGroundWithSnow;
			}
			
			for (int i = 0; i < groundParent.transform.childCount;i++){
				groundParent.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = brownGroundWithSnow;
			}
			if (mainCamera){
				mainCamera.backgroundColor = brownGroundThemeColor;
			}
			break;

		case Themes.Rock : 
			for (int i = 0; i < roofParent.transform.childCount;i++){
				roofParent.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = rock;
			}
			
			for (int i = 0; i < groundParent.transform.childCount;i++){
				groundParent.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = rock;
			}
			if (mainCamera){
				mainCamera.backgroundColor = rockGroundThemeColor;
			}
			break;

		case Themes.Snow : 
			for (int i = 0; i < roofParent.transform.childCount;i++){
				roofParent.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = snow;
			}
			
			for (int i = 0; i < groundParent.transform.childCount;i++){
				groundParent.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = snow;
			}
			if (mainCamera){
				mainCamera.backgroundColor = snowGroundThemeColor;
			}
			break;
		}
		lastTheme = currentTheme;
	}

	// Update is called once per frame
	void Update () {
		if (!brownGround || !brownGroundWithGrass || !brownGroundWithSnow || !snow || !rock) {
			Debug.LogWarning("Some variables missing");
			return;
		}

		if (lastTheme != currentTheme) {
			ChangeGraphics();
		}
	}

	void Theame (int r){
		switch (r) {
			case 0 : currentTheme = Themes.BrownGround; break;
			case 1 : currentTheme = Themes.BrownGroundWithGrass; break;
			case 2 : currentTheme = Themes.BrownGroundWithSnow; break;
			case 3 : currentTheme = Themes.Rock; break;
			case 4 : currentTheme = Themes.Snow; break;
		}
	}
}
