using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class EventOptionDisplay : MonoBehaviour {
	public Button button;
	public TextMeshProUGUI title;
	public Card card;
	public ImpactIcon impactIcon1;
	public ImpactIcon impactIcon2;
	public ImpactIcon impactIcon3;

	private EventPanel eventPanel;
	private EventOption eventOption;
	private QualityIcons qualityIcons;


	// Initializes the card to use a particular CardInfo
	public void setEventOption(EventOption newEventOption, bool local_authority, EventPanel _eventPanel) {
		eventPanel = _eventPanel;
		eventOption = newEventOption;

		button.interactable = local_authority;
		title.text = eventOption.title;

		if (eventOption.impacts.Count > 0) {
			impactIcon1.setImpact(eventOption.impacts[0]);
			if (eventOption.impacts.Count > 1) {
				impactIcon2.setImpact(eventOption.impacts[1]);
				if (eventOption.impacts.Count > 2) {
					impactIcon3.setImpact(eventOption.impacts[2]);
				}
			}
		}

		card.setCardInfo(eventOption.cardGained, false);
	}


	// Called when the button is clicked. Selects this option.
	public void selectOption() {
		if (eventPanel.optionChosen) return;
		eventPanel.optionChosen = true;
		// Impact the stuff
		Card.apply_impact_list(eventOption.impacts, null);
		// Shuffle the card into the decks
		Net.SendCardToBeShuffled(eventOption.cardGained.title);
		// Destroy this panel
		Net.Destroy(eventPanel.thisNetObj.netVariables.uniqueId);
	}
}
