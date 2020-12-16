using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerList : MonoBehaviour {
	public TextMeshProUGUI textMeshPro;


	// Update is called once per frame
	void Update() {
		string txt = "";
		if (Net.connected && Net.players != null) {
			txt = "Government Officials:\n";
			foreach (Player player in Net.players.Values) {
				txt += player.nickName + "\n";
			}
		} else {
			txt = "Connecting...";
		}
		textMeshPro.text = txt;
	}
}
