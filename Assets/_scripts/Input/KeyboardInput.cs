using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour {
	// Update is called once per frame
	void Update() {
		if (Input.GetKey(KeyCode.Escape)) {
			Quit();
		}
	}


	// Quit the game
	public void Quit() {
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}
}
