﻿using UnityEngine;
using System.Collections;

public static class Initiate {
	public static void Fade (string scene,Color col,float damp){
		//Creating a gameobject and assigning the fader script then activating it
		GameObject init = new GameObject ();
		init.name = "Fader";
		init.AddComponent<Fader> ();
		Fader scr = init.GetComponent<Fader> ();
		scr.fadeDamp = damp;
		scr.fadeScene = scene;
		scr.fadeColor = col;
		scr.start = true;
	}
}
