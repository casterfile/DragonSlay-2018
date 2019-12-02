using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	public void RestartGame(){
		Application.LoadLevel("Scene_Game");
		print("Hello world");
	}

	public void SkipGame(){
		Application.LoadLevel("Scene_Game_05");
		print("Hello world");
	}
}
