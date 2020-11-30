using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {
	// Fields
	public Button button;
	public Text title;
	public Text description;
	public Image icon;
	public Image backgroundImage;
	public regionView regionV;

	private CardInfo cardInfo;
	private CardIcons cardIcons;

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
/*		if (cardIcons == null)
        {
			Debug.Log("Panic! This card doesn't have a CARD_ICONS scriptable object assigned to it. Please assign one ");
			return;
        }*/
		button.interactable = true;
		title.text = cardInfo.title;
		description.text = cardInfo.description;
		backgroundImage.sprite = cardInfo.background;
		icon.sprite = cardIcons.IconSprites[(int)CardInfo.Effects.Effect1];
	}


	// Called when this is clicked
	public void whenClicked() {
		if (!regionV.currentRegion) {
			Debug.Log("no current region");
			return;
		}

		if (cardInfo == null) return;
		PlayableCardInfo pCardInfo = cardInfo as PlayableCardInfo;

		if (!pCardInfo) {
			Debug.LogWarning("A CardInfo that's not a PlayableCardInfo ended up in your hand somehow... (Dom might not have implemented events yet)");
			setCardInfo(null);
			return;
		}

		NetVariables netVariables = regionV.currentRegion.netVariables;
		NetVariables incrVariables = NetVariables.makeIncrCopy(netVariables);

		for (int i=0; i < pCardInfo.impacts.Count; i++) {
			Impact impact = pCardInfo.impacts[i];
			netVariables.qualityStates.states[(int)impact.quality] += impact.getScaledAmount();
			incrVariables.qualityStates.states[(int)impact.quality] += impact.getScaledAmount();
		}
		//Net.SetVariables(netVariables.uniqueId, netVariables);
		Net.IncrVariables(netVariables.uniqueId, incrVariables);
		setCardInfo(null);
	}

	
	// Returns true iff this card slot is empty
	public bool is_waiting_for_card() {
		return cardInfo == null;
	}
}
