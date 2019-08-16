using UnityEngine;
using System.Collections;

public class LogoScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Load game after 2 second
		Invoke ("LoadGame", 2.0f);	
	}


	void LoadGame (){
		//Start fading effect
		Initiate.Fade ("Game", Color.black, 2.0f);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
