using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dealer : MonoBehaviour {

	public Decklist decklist;
	public List<Card> cardButtons;
	public float dealTime = 9.9f;

	public bool fill_hand_at_start = true;

	public TextMeshProUGUI card_draw_timer;

	private List<CardInfo> deck;
	private float timer = 0.0f;


	//init
	private void Awake() {
		deck = new List<CardInfo>(decklist.cardInfos);
		timer = dealTime;

		// Deal to every card slot that isn't filled
		if (fill_hand_at_start) {
			foreach (Card card in cardButtons) {
				if (card.is_waiting_for_card()) {
					CardInfo newCardInfo = drawCard();
					card.setCardInfo(newCardInfo);
				}
			}
		}
	}

	// Update is called once per frame
	void Update() {
		if (timer > 0) {
			card_draw_timer.text = "Next card: " + timer.ToString("F1");
			timer -= Time.deltaTime;
			return;
		}
		card_draw_timer.text = "Next card: 0.0";

		if (deck.Count <= 0) return;
		
		// Try to find a card slot to deal to
		foreach (Card card in cardButtons) {
			if (card.is_waiting_for_card()) {
				CardInfo newCardInfo = drawCard();
				card.setCardInfo(newCardInfo);
				timer = dealTime;
				break;
			}
		}
	}


	// Removes a CardInfo from the deck then returns it
	CardInfo drawCard() {
		if (deck.Count <= 0) return null;
		int index = Random.Range(0, deck.Count);
		CardInfo info = deck[index];
		deck.RemoveAt(index);
		return info;
	}
}
