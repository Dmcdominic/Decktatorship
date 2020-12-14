using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dealer : MonoBehaviour {

	public List<Decklist> decklists_by_role;
	public Decklist cardRegistry;
	public List<Card> cardButtons;
	public float dealTime = 9.9f;

	public bool fill_hand_at_start = true;

	public TextMeshProUGUI card_draw_timer;

	private Decklist chosen_decklist = null;
	private List<CardInfo> deck;
	private float timer = 0.0f;


	//init
	private void Start() {
		refillDeck();
		timer = dealTime;

		// Deal to every card slot that isn't filled
		if (fill_hand_at_start) {
			tryToDraw(true, true);
		}
	}


	// Update is called once per frame
	void Update() {
		if (timer > 0) {
			card_draw_timer.text = "Days til Resupply: " + timer.ToString("F0");
			timer -= Time.deltaTime;
			return;
		}
		card_draw_timer.text = "Days til Resupply: 0";

		// Try to find a card slot to deal to
		tryToDraw();
	}


	// Finds an open card slot in your hand to draw a card, or does nothing if it's full.
	// If fill_hand is set, fill every open card slot.
	private void tryToDraw(bool fill_hand = false, bool no_events = false) {
		foreach (Card card in cardButtons) {
			if (card.is_waiting_for_card()) {
				CardInfo newCardInfo = drawCard(no_events);
				if (newCardInfo is PlayableCardInfo) {
					card.setCardInfo(newCardInfo as PlayableCardInfo);
				} else if (newCardInfo is EventCardInfo) {
					EventCardInfo eventCardInfo = newCardInfo as EventCardInfo;
					Net.Instantiate("Event Panel", Net.TEMPORARY, new Vector3(), new NetVariables("TBD", "N/A", eventCardInfo, false, false));
				} else {
					throw new System.Exception("No case in Dealer for newCardInfo: " + newCardInfo);
				}
				timer = dealTime;
				if (!fill_hand) break;
			}
		}
	}


	// Removes a CardInfo from the deck then returns it
	private CardInfo drawCard(bool no_events = false) {
		bool contains_non_event_card = false;
		if (no_events) {
			for (int i=0; i < deck.Count; i++) {
				if (!(deck[i] is EventCardInfo)) {
					contains_non_event_card = true;
					break;
				}
			}
			if (!contains_non_event_card) {
				refillDeck();
			}
		}
		if (deck.Count <= 0) {
			refillDeck();
		}

		int index = -1;
		CardInfo info = null;
		while (info == null || (no_events && (info is EventCardInfo))) {
			index = Random.Range(0, deck.Count);
			info = deck[index];
		}
		deck.RemoveAt(index);
		return info;
	}


	// Fills the deck with a new copy of the decklist
	private void refillDeck() {
		if (chosen_decklist == null) {
			if (Net.manager.my_player_index < 0) {
				throw new System.Exception("my_player_index not set by NetManager (we're not connected)");
			}
			//chosen_decklist = potential_decklists[Random.Range(0, potential_decklists.Count)];
			chosen_decklist = decklists_by_role[Net.manager.my_player_index % decklists_by_role.Count];
		}
		deck = new List<CardInfo>(chosen_decklist.cardInfos);
	}


	// Adds a new card into the deck
	public void shuffleIntoDeck(string cardTitle) {
		deck.Add(cardRegistry.getCardInfoByTitle(cardTitle));
	}
}
