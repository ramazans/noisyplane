using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {
	//Start the fading process
	public bool start = false;
	//How fast?
	public float fadeDamp = 0.0f; 
	//what scene to load
	public string fadeScene;
	//Alpha value of the texture
	public float alpha = 0.0f;
	//What color to fade through
	public Color fadeColor;
	//Are we fading in or out
	public bool isFadeIn = false;
	// Use this for initialization
	void Start () {
	
	}
	

	void OnGUI () {
		//if not started go back
	if (!start)
			return;

		//Creating texure and fading
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);

		Texture2D myTex;
		myTex = new Texture2D (1, 1);
		myTex.SetPixel (0, 0, fadeColor);
		myTex.Apply ();

		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), myTex);

		//Fading in and fading out
		if (isFadeIn)
			alpha = Mathf.Lerp (alpha, -0.1f, fadeDamp * Time.deltaTime);
		else
			alpha = Mathf.Lerp (alpha, 1.1f, fadeDamp * Time.deltaTime);

		if (alpha >= 1 && !isFadeIn) {
			Application.LoadLevel (fadeScene);		
			DontDestroyOnLoad(gameObject);		
		} else
		if (alpha <= 0 && isFadeIn) {
			Destroy(gameObject);		
		}

	}
	//Go into fade in mode
	void OnLevelWasLoaded (int level){
		isFadeIn = true;
	}

}
