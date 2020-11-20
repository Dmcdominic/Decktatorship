using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {
	// Fields
	public CardInfo cardInfo;
	public Text title;
	public Text description;

	public regionView regionV;


	// Methods
	private void Awake() {
		//Debug.Log(cardInfo.title);
		Debug.Log(this);
		title.text = cardInfo.title;
		description.text = cardInfo.description;
	}


	public void whenClicked() {
		if (!regionV.currentRegion) {
			Debug.LogError("no current region");
			return;
		}
		for (int i=0; i < cardInfo.impacts.Count; i++) {
			Impact impact = cardInfo.impacts[i];
			regionV.currentRegion.netVariables.qualityStates.states[(int)impact.quality] += impact.getScaledAmount();
		}
		Net.SetVariables(regionV.currentRegion.netVariables.uniqueId, regionV.currentRegion.netVariables);
	}
}
