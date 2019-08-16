using UnityEngine;
using System.Collections;

public class BrokenPlaneEndGame : MonoBehaviour {
	public Animator UI;
	public SceneLooper sceneLooper;
	ScoreHolder scoreHolder;
	// Use this for initialization
	void Start () {
		if (GameObject.FindObjectOfType<ScoreHolder> ()) {
			scoreHolder = GameObject.FindObjectOfType<ScoreHolder> ();
		} else {
			Debug.LogWarning("ScoreHolder not found");
		}

		if (UI && sceneLooper && scoreHolder) {
			Invoke ("EndGame", 2.0f);
		} else {
			Debug.LogWarning("Some variables missing");
		}

	}

	void EndGame (){
		UI.SetTrigger("Ended");
		scoreHolder.gameObject.SendMessage("EndGame",SendMessageOptions.RequireReceiver);
	}

	// Update is called once per frame
	void Update () {
		if (sceneLooper) {
			sceneLooper.sceneSpeed = Mathf.Lerp(sceneLooper.sceneSpeed,0.0f,Time.deltaTime);
		}
	}
}
