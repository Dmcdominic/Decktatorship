using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Restart : MonoBehaviour {

	private bool was_once_connected = false;


	// Update is called once per frame
	void Update() {
		// when you detect a disconnection, reload.
		if (Net.connected) {
			was_once_connected = true;
		}
		if (was_once_connected && !Net.connected) {
			reload();
		}
	}


	// Disconnects from the server and reloads.
	// Static variables must reset themselves in an Awake() function.
	public static void restart() {
		//if (Net.authority) {
			Net.SendRestart();
		//}
		reload();
	}

	// Non-static function required for OnClick()
	public void restart_() {
		restart();
	}


	// Reload everything (specifically, restarts the scene).
	public static void reload() {
		if (Net.connected) {
			Net.manager.socket.Close();
		}
		qualityDecay.regionNetObs = new Dictionary<string, NetObject>();
		Time.timeScale = 1;
		//SceneManager.LoadScene(0);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
