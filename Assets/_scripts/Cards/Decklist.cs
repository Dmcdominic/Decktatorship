using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Info for a deck of cards
[CreateAssetMenu(menuName = "custom/Decklist")]
public class Decklist : ScriptableObject {
	// Fields
	public string Title;
	public List<CardInfo> cardInfos;

	// used for the cardRegistry
	public CardInfo getCardInfoByTitle(string title) {
		foreach (CardInfo cardInfo in cardInfos) {
			if (cardInfo.title.Equals(title)) {
				return cardInfo;
			}
		}
		throw new System.Exception("Couldn't find card with title: " + title + " in Decklist titled: " + Title);
	}
}
