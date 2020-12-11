using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Card : MonoBehaviour {
	// Fields
	public Button button;
	public TextMeshProUGUI title;
	public TextMeshProUGUI description;

	public Image icon;
	public Image backgroundImage;

	public ImpactIcon impactIcon1;
	public ImpactIcon impactIcon2;

	public Sprite defaultBackgroundImg;

	public regionView regionV;

	private PlayableCardInfo playableCardInfo = null;
	private CardIcons cardIcons;


	// Initializes the card to use a particular CardInfo
	public void setCardInfo(PlayableCardInfo newCardInfo, bool interactable = true) {
		//if (!Net.connected) return;
		playableCardInfo = newCardInfo;
		if (playableCardInfo == null) {
			button.interactable = false;
			title.text = "";
			description.text = "waiting for next card...";
			backgroundImage.sprite = null;
			return;
		}
/*		if (cardIcons == null)
        {
			Debug.Log("Panic! This card doesn't have a CARD_ICONS scriptable object assigned to it. Please assign one ");
			return;
        }*/
		button.interactable = interactable;
		title.text = playableCardInfo.title;
		description.text = playableCardInfo.description;
		if (playableCardInfo && playableCardInfo.background) {
			backgroundImage.sprite = playableCardInfo.background;
		} else {
			backgroundImage.sprite = defaultBackgroundImg;
		}
		//icon.sprite = cardIcons.IconSprites[(int)playableCardInfo.impacts[0].quality];
		if (playableCardInfo.impacts.Count > 0) {
			impactIcon1.setImpact(playableCardInfo.impacts[0]);
			if (playableCardInfo.impacts.Count > 1) {
				impactIcon2.setImpact(playableCardInfo.impacts[1]);
			}
		}
	}


	// Called when this is clicked
	public void whenClicked() {
		if (!regionV.currentRegion) {
			Debug.Log("no current region");
			return;
		}

		if (playableCardInfo == null) return;
		apply_impact_list(playableCardInfo.impacts, regionV);
		sendCardToStack(playableCardInfo.title);
		setCardInfo(null);
	}

	
	// Returns true iff this card slot is empty
	public bool is_waiting_for_card() {
		return playableCardInfo == null;
	}


	// Sends to the server a card to be stacked onto this region
	private void sendCardToStack(string cardTitle) {
		NetVariables netVars = NetVariables.makeIncrCopy(regionV.currentRegion.netVariables);
		netVars.cardToStack = cardTitle;
		Net.IncrVariables(regionV.currentRegion.netVariables.uniqueId, netVars);
	}


	// Apply an impact list to all regions
	public static void apply_impact_list(List<Impact> impacts, regionView regionV) {
		// Create a NetVariables object for each region to track increments
		Dictionary<string, NetVariables> incrVariables = new Dictionary<string, NetVariables>(); // Key = uniqueID
		foreach (NetObject netObj in qualityDecay.regionNetObs.Values) {
			incrVariables.Add(netObj.netVariables.uniqueId, NetVariables.makeIncrCopy(netObj.netVariables));
		}

		// Apply each impact to incrVariables, and to the local NetVariables
		for (int i = 0; i < impacts.Count; i++) {
			Impact impact = impacts[i];
			if (impact.locality == Locality.LOCAL) {
				if (regionV == null) throw new System.Exception("LOCAL locality used without a regionView");
				string uniqueId = regionV.currentRegion.netVariables.uniqueId;
				incrVariables[uniqueId].qualityStates.states[(int)impact.quality] += impact.getScaledAmount();
				qualityDecay.regionNetObs[uniqueId].netVariables.qualityStates.states[(int)impact.quality] += impact.getScaledAmount();
			} else if (impact.locality == Locality.ADJACENT) {
				if (regionV == null) throw new System.Exception("ADJACENT locality used without a regionView");
				// TODO
				throw new System.Exception("ADJACENT locality of impacts not yet implemented");
			} else if (impact.locality == Locality.GLOBAL) {
				foreach (NetVariables netVars in incrVariables.Values) {
					netVars.qualityStates.states[(int)impact.quality] += impact.getScaledAmount();
				}
				foreach (NetObject netObj in qualityDecay.regionNetObs.Values) {
					netObj.netVariables.qualityStates.states[(int)impact.quality] += impact.getScaledAmount();
				}
			}
		}

		// Send each inrVariables (as long as at least one state has been changed)
		foreach (NetVariables netVars in incrVariables.Values) {
			foreach (int state in netVars.qualityStates.states) {
				if (state != 0) {
					Net.IncrVariables(netVars.uniqueId, netVars);
					break;
				}
			}
		}
	}
}
