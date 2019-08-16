using UnityEngine;
using System.Collections;

public class Reload : MonoBehaviour {
	// Use this for initialization

    public static int gameOverCount = 0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//Reload the same scene
	void ReloadLevel (){
        gameOverCount++;
        Debug.Log("gameover log:" +gameOverCount);
        Initiate.Fade(Application.loadedLevelName,Color.black,2.0f);
	}
}
