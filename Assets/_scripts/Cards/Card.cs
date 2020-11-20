using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {
	// Fields
	public Button button;
	public Text title;
	public Text description;

	public regionView regionV;

	private CardInfo cardInfo;


	// init
	private void Awake() {
		setCardInfo(cardInfo);
	}


	// Initializes the card to use a particular CardInfo
	public void setCardInfo(CardInfo newCardInfo) {
		cardInfo = newCardInfo;
		if (cardInfo == null) {
			title.text = "";
			description.text = "waiting for next card...";
			button.interactable = false;
			return;
		}
		button.interactable = true;
		title.text = cardInfo.title;
		description.text = cardInfo.description;
	}


	// Called when this is clicked
	public void whenClicked() {
		if (cardInfo == null) return;

		if (!regionV.currentRegion) {
			Debug.Log("no current region");
			return;
		}
		for (int i=0; i < cardInfo.impacts.Count; i++) {
			Impact impact = cardInfo.impacts[i];
			regionV.currentRegion.netVariables.qualityStates.states[(int)impact.quality] += impact.getScaledAmount();
		}
		Net.SetVariables(regionV.currentRegion.netVariables.uniqueId, regionV.currentRegion.netVariables);
		setCardInfo(null);
	}

	
	// Returns true iff cardInfo is null
	public bool is_waiting_for_card() {
		return cardInfo == null;
	}
}
