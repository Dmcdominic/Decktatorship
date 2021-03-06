﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverObserver : MonoBehaviour {
	public GameObject gameOverScreen;

	public static bool gameIsOver;


	// init
	private void Awake() {
		gameIsOver = false;
		gameOverScreen.SetActive(false);
	}


	// Update is called once per frame
	void Update() {
		if (gameIsOver) return;
		if (qualityDecay.regionNetObs == null) return;
		foreach (NetObject netObj in qualityDecay.regionNetObs.Values) {
			foreach (int state in netObj.netVariables.qualityStates.states) {
				if (state <= QualityStates.MIN) {
					endTheGame();
					return;
				}
			}
		}
	}


	// Ends the game
	private void endTheGame() {
		gameOverScreen.SetActive(true);
		gameIsOver = true;
		Time.timeScale = 0;
		Net.manager.socket.Close();
	}
}
