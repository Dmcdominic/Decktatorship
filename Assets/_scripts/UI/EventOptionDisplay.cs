using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class EventOptionDisplay : MonoBehaviour {
	public Button button;
	public TextMeshProUGUI title;
	//public Text description;
	//public Image icon;
	//public Image backgroundImage;
	public Card card;

	private EventPanel eventPanel;
	private EventOption eventOption;
	private CardIcons cardIcons;


	// Initializes the card to use a particular CardInfo
	public void setEventOption(EventOption newEventOption, bool local_authority, EventPanel _eventPanel) {
		eventPanel = _eventPanel;
		eventOption = newEventOption;

		button.interactable = local_authority;
		title.text = eventOption.title;
		//description.text = eventOption.description;
		//backgroundImage.sprite = eventOption.background;
		//icon.sprite = cardIcons.IconSprites[(int)eventOption.impacts[0].quality];

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
